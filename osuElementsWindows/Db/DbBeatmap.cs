using System;
using System.Collections.Generic;
using osuElements.Api;
using osuElements.Beatmaps;
using osuElements.Helpers;

namespace osuElements.Db
{
    public enum DbBeatmapState
    {
        None,
        Unsubmitted,
        Graveyard,
        WorkInProgress,
        Ranked,
        Approved,
        Qualified,
    }
    /// <summary>
    /// The database-driven approach to the beatmap object
    /// </summary>
    public class DbBeatmap : Beatmap
    {
        public DbBeatmap() {

            StandardDifficulties = new Dictionary<Mods, double>();
            TaikoDifficulties = new Dictionary<Mods, double>();
            ManiaDifficulties = new Dictionary<Mods, double>();
            CtbDifficulties = new Dictionary<Mods, double>();
        }

        public DbBeatmapState DbBeatmapState { get; set; }
        public ushort HitCircleAmount { get; set; }
        public ushort SliderAmount { get; set; }
        public ushort SpinnerAmount { get; set; }
        public ICollection<KeyValuePair<Mods, double>> StandardDifficulties { get; set; }
        public ICollection<KeyValuePair<Mods, double>> TaikoDifficulties { get; set; }
        public ICollection<KeyValuePair<Mods, double>> CtbDifficulties { get; set; }
        public ICollection<KeyValuePair<Mods, double>> ManiaDifficulties { get; set; }
        public ScoreRank HighestTaikoRank { get; set; }
        public ScoreRank HighestStandardRank { get; set; }
        public ScoreRank HighestCtbRank { get; set; }
        public ScoreRank HighestManiaRank { get; set; }
        public short UserOffset { get; set; }
        public short OnlineOffset { get; set; }
        public string TitleMarkdown { get; set; }
        public bool IgnoreHitsounds { get; set; }
        public bool IgnoreSkin { get; set; }
        public bool IgnoreStoryboard { get; set; }
        public bool IgnoreVideo { get; set; }
        public DateTime DownloadDate { get; set; }
        public DateTime LastRead { get; set; }
        public DateTime LastPlayTime { get; set; }
        public bool Unplayed { get; set; }

        //Unsure
        public int Int { get; set; } //nearly always 0
        public bool Bool1 { get; set; } //always false
        public bool Bool2 { get; set; } //always false
        public byte Byte { get; set; } //always 0
    }
}