using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SearchAPI.Models;
using System.Net;
using System.IO;
using System.Text;
using SearchAPI.Data;

namespace SearchAPI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index(string searchString)
        {
            var searchResults = new DisplayObjectViewModel();
            if (!String.IsNullOrEmpty(searchString))
            {
                searchResults.List = await ITunesSearch.GetSearchResults(searchString);
            }
            return View(searchResults);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Click counts for each track result";

            var clickList = new List<RecordTrack>();

            return View(clickList);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
