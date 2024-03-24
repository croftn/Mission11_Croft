//Author: Nya Croft
//Section 004

using Microsoft.AspNetCore.Mvc;
using Mission11_Croft.Models;
using Mission11_Croft.Models.ViewModels;
using System.Diagnostics;

namespace Mission11_Croft.Controllers
{
    public class HomeController : Controller
    {
        private IBookRepository _repo;
        public HomeController(IBookRepository temp)
        {
            _repo = temp;
        }

        // Action method for handling request to the root URL or home page, with pagination support.
        public IActionResult Index(int pageNum)
        {
            int pageSize = 10; // Defines number of items to show per page

            var blah = new BookListViewModel
            {
                //Fetches books and applies pagination
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                //Sets up pagination info including the current page, items per page, and total items 
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = pageSize,
                    TotalItems = _repo.Books.Count()
                }

            };

            return View(blah);
        }

    }
}
