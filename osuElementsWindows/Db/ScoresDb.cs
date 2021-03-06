﻿using System.Collections.Generic;
using System.IO;
using osuElements.IO.Binary;
using osuElements.IO.File;
using osuElements.Replays;

namespace osuElements.Db
{
    public class ScoresDb
    {
        public ScoresDb() {
            ScoreLists = new List<ScoreList>();
        }

        public List<ScoreList> ScoreLists { get; set; }
        public int FileVersion { get; set; }

        public static BinaryFile<ScoresDb> FileReader() {
            var result = new BinaryFile<ScoresDb>(
                new BinaryFileLine<ScoresDb, int>(s => s.FileVersion),
                new BinaryCollection<ScoresDb, ScoreList>(s => s.ScoreLists,
                    new BinaryFileLine<ScoreList, string>(s => s.MapHash),
                    new BinaryCollection<ScoreList, Replay>(l => l.Replays,
                Replay.HeaderFileLines())));
            return result;
        }

        public class ScoreList
        {
            public string MapHash { get; set; }
            public List<Replay> Replays { get; set; } = new List<Replay>();
            public override string ToString() {
                return MapHash;
            }
        }
        #region File
        public bool IsRead { get; private set; }
        public string Directory { get; set; } = osuElements.OsuDirectory;
        public string FileName { get; set; } = "scores.db";
        public string FullPath
        {
            get { return Path.Combine(Directory, FileName); }
            set
            {
                Directory = Path.GetDirectoryName(value);
                FileName = Path.GetFileName(value);
            }
        }
        public void ReadFile(ILogger logger = null) {
            osuElements.ScoresDbRepository.ReadFile(osuElements.ReadStream(FullPath), this, logger);
            IsRead = true;
        }

        public void WriteFile() {
            osuElements.ScoresDbRepository.WriteFile(osuElements.WriteStream(FullPath), this);
        }
        #endregion
    }
}