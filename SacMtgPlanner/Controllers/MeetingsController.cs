using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacMtgPlanner.Models;

namespace SacMtgPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly SacMtgPlannerContext _context;

        public MeetingsController(SacMtgPlannerContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index(string meetingSubject, string searchString, string sortOrder)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> subjectQuery = from m in _context.Meeting
                                            orderby m.Subject
                                            select m.Subject;
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            var meetings = from m in _context.Meeting
                         select m;
            if (!String.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "Date":
                        meetings = meetings.OrderBy(m => m.ReleaseDate);
                        break;
                    case "date_desc":
                        meetings = meetings.OrderByDescending(m => m.ReleaseDate);
                        break;
                    default:
                        meetings = meetings.OrderBy(m => m.Subject);
                        break;
                }
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                meetings = meetings.Where(s => s.Conducting.Contains(searchString));
            }


            if (!String.IsNullOrEmpty(meetingSubject))
            {
                meetings = meetings.Where(x => x.Subject == meetingSubject);

            }
            var meetingSubjectVM = new SubjectViewModel();
            meetingSubjectVM.subjects = new SelectList(await subjectQuery.Distinct().ToListAsync());
            meetingSubjectVM.meetings = await meetings.AsNoTracking().ToListAsync();


            return View(meetingSubjectVM);



        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Subject,ReleaseDate,Conducting,OpenPrayer,ClosePrayer,YouthSpeaker,FirstSpeaker,SecondSpeaker,OpenHymn,SacHymn,CloseHymn")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Subject,ReleaseDate,Conducting,OpenPrayer,ClosePrayer,YouthSpeaker,FirstSpeaker,SecondSpeaker,OpenHymn,SacHymn,CloseHymn")] Meeting meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meeting
                .SingleOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meeting.SingleOrDefaultAsync(m => m.ID == id);
            _context.Meeting.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meeting.Any(e => e.ID == id);
        }
    }
}
