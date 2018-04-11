using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SacMtgPlanner.Models
{
    public class Meeting
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Subject { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Conducting { get; set; }

        [StringLength(30)]
        [Display(Name = "Opening Prayer")]
        public string OpenPrayer { get; set; }

        [StringLength(30)]
        [Display(Name = "Closing Prayer")]
        public string ClosePrayer { get; set; }

        [StringLength(30)]
        [Display(Name = "Youth Speaker")]
        public string YouthSpeaker { get; set; }

        [StringLength(30)]
        [Display(Name = "First Speaker")]
        public string FirstSpeaker { get; set; }

        [StringLength(30)]
        [Display(Name = "Second Speaker")]
        public string SecondSpeaker { get; set; }

        [StringLength(60)]
        [Display(Name = "Opening Hymn")]
        public string OpenHymn { get; set; }

        [StringLength(60)]
        [Display(Name = "Sacrament Hymn")]
        public string SacHymn { get; set; }

        [StringLength(60)]
        [Display(Name = "Closing Hymn")]
        public string CloseHymn { get; set; }
    }
}
