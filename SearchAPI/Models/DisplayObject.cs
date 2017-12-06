using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SearchAPI.Models
{
    public class DisplayObject
    {
        [Display(Name = "Image")]
        public string ArtworkUrl30 { get; set; }
        [Display(Name = "Track Name")]
        public string TrackName { get; set; }
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }
        [Display(Name = "Track ID")]
        public int TrackID { get; set; }
        public string URL { get; set; }
        [Display(Name = "Type")]
        public string Kind { get; set; }
        public string ArtistViewUrl { get; set; }
        public string TrackViewUrl { get; set; }

    }
}
