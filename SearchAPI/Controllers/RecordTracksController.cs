using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SearchAPI.Data;
using SearchAPI.Models;

namespace SearchAPI.Controllers
{
    public class RecordTracksController : Controller
    {
        private readonly SearchAPIContext _context;

        public RecordTracksController(SearchAPIContext context)
        {
            _context = context;
        }

        // GET: RecordTracks
        public IActionResult Index()
        {
            var clickRecords = ClickCountRepository.Instance.GetClickDictionaryForDisplay();
            return View(clickRecords);
        }

        // GET: RecordTracks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordTrack = await _context.RecordTrack
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recordTrack == null)
            {
                return NotFound();
            }

            return View(recordTrack);
        }

        // GET: RecordTracks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RecordTracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int trackId)
        {
            if (ModelState.IsValid)
            {
                var newRecord = new RecordTrack();
                newRecord.TrackID = trackId;
                newRecord.ID = trackId;
                newRecord.ClickCount = 1;
                _context.Add(newRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return null;
        }

        // GET: RecordTracks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordTrack = await _context.RecordTrack.SingleOrDefaultAsync(m => m.ID == id);
            if (recordTrack == null)
            {
                return NotFound();
            }
            return View(recordTrack);
        }

        // POST: RecordTracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RecordTrack recordTrack)
        {
            recordTrack.ClickCount++;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recordTrack);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecordTrackExists(recordTrack.ID))
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
            return View(recordTrack);
        }

        // GET: RecordTracks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recordTrack = await _context.RecordTrack
                .SingleOrDefaultAsync(m => m.ID == id);
            if (recordTrack == null)
            {
                return NotFound();
            }

            return View(recordTrack);
        }

        // POST: RecordTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recordTrack = await _context.RecordTrack.SingleOrDefaultAsync(m => m.ID == id);
            _context.RecordTrack.Remove(recordTrack);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecordTrackExists(int id)
        {
            return _context.RecordTrack.Any(e => e.ID == id);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult RecordClick(int? trackID, string url)
        {
            if (trackID == null)
            {
                return NotFound();
            }

            //This could be persisted to the DB, but for simplicity of the demo data is stored within memory.
            ClickCountRepository.Instance.MergeClickRecord(trackID.Value);

            return Redirect(url);
        }
    }
}
