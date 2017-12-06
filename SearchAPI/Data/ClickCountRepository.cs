using SearchAPI.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace SearchAPI.Data
{
    public class ClickCountRepository
    {
        private static readonly Lazy<ClickCountRepository> instance = new Lazy<ClickCountRepository>(() => new ClickCountRepository());
        private readonly ConcurrentDictionary<int, int> clickCountDictionary = new ConcurrentDictionary<int, int>();

        public static ClickCountRepository Instance => instance.Value;

        private ClickCountRepository()
        {
        }

        public void MergeClickRecord(int trackID)
        {
            clickCountDictionary.AddOrUpdate(trackID, 1, (key, value) => ++value);
        }

        public IReadOnlyDictionary<int, int> GetClickDictionary()
        {
            return clickCountDictionary;
        }

        public IReadOnlyList<RecordTrack> GetClickDictionaryForDisplay()
        {
            return clickCountDictionary.Select(s => new RecordTrack(){ TrackID = s.Key, ID = s.Key, ClickCount = s.Value }).ToList();
        }
    }
}
