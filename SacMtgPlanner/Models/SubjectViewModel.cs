using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SacMtgPlanner.Models
{
    public class SubjectViewModel
    {
        public List<Meeting> meetings;
        public SelectList subjects;
        public string meetingSubject { get; set; }
    }
}
