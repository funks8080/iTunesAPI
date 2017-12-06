using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.Models
{
    public class RecordTrack
    {
        public int ID { get; set; }
        [Display(Name = "Track ID")]
        public int TrackID { get; set; }
        public string Image { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
        public string URL { get; set; }
        public string Type { get; set; }
        [Display(Name = "Click Count")]
        public int ClickCount { get; set; }
    }
}
