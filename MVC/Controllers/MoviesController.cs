#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using Data_Access.Entities;
using Business;
using Business.Models;
using Business.Results.Bases;
using Business.Services;

//Generated from Custom Template.
namespace MVC.Controllers
{
    public class MoviesController : Controller
    {
        // TODO: Add service injections here
        private readonly IMovieService _movieService;
        private readonly IDirectoryService _directoryService;

        public MoviesController(IMovieService movieService, IDirectoryService directoryService)
        {
            _movieService = movieService;
           _directoryService = directoryService;
        }

        // GET: Movies
        public IActionResult Index()
        {
            List<MovieModel> movieList = _movieService.Query().ToList(); ; // TODO: Add get list service logic here
            return View(movieList);
        }

        // GET: Movies/Details/5
        public IActionResult Details(int id)
        {
            MovieModel movie = _movieService.Query().SingleOrDefault(u => u.id == id); // TODO: Add get item service logic here
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        public IActionResult Create()
        {
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
           ViewBag.Directors = new SelectList(_directoryService.Query().ToList(), "Id", "UserName");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MovieModel movie)
        {
            if (ModelState.IsValid)
            {
                // If model data is valid, insert service logic should be written here.
                Result result = _movieService.Add(movie); // result referenced object can be of type SuccessResult or ErrorResult
                if (result.IsSuccessful)
                {
                    // Way 1:
                    //return RedirectToAction("GetList");
                    // Way 2:
                    TempData["Message"] = result.Message; // if there is a redirection, the data should be carried with TempData to the redirected action's view
                    return RedirectToAction(nameof(Index)); // redirection to the action specified of this controller to get the updated list from database
                }

                // Way 1:  carrying data from the action with ViewData
                //ViewBag.Message = result.Message; // ViewData["Message"] = result.Message;
                // Way 2: sends data to view's validation summary

                ModelState.AddModelError("", result.Message);
            }
            // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
            ViewBag.Directors = new SelectList(_directoryService.Query().ToList(), "Id", "UserName");
            return View(movie);
        }










        //// GET: Movies/Create
        //public IActionResult Create()
        //{
        //    // TODO: Add get related items service logic here to set ViewData if necessary and update null parameter in SelectList with these items
        //    ViewBag.Directors = new SelectList(_directoryService.Query().ToList(), "Id", "UserName");
        //    return View();
        //}



        //// get: movies/edit/5
        //public ıactionresult edit(int id)
        //{
        //    moviemodel movie = _movieservice.query().singleordefault(u => u.id == id); ; // todo: add get item service logic here
        //    if (movie == null)
        //    {
        //        return notfound();
        //    }
        //    // todo: add get related items service logic here to set viewdata if necessary and update null parameter in selectlist with these items
        //    viewbag.directors = new selectlist(_directoryservice.query().tolist(), "ıd", "username");
        //    return view(movie);
        //}

        //// post: movies/edit
        //// to protect from overposting attacks, enable the specific properties you want to bind to.
        //// for more details, see http://go.microsoft.com/fwlink/?linkıd=317598.
        //[httppost]
        //[validateantiforgerytoken]
        //public ıactionresult edit(moviemodel movie)
        //{
        //    if (modelstate.ısvalid)
        //    {
        //        var result = _movieservice.update(movie); // update the user in the service
        //        if (result.ıssuccessful)
        //        {
        //            // if update operation result is successful, carry successful result message to the list view through the getlist action
        //            tempdata["message"] = result.message;
        //            return redirecttoaction(nameof(ındex));
        //        }
        //        modelstate.addmodelerror("", result.message);
        //    }
        //    // todo: add get related items service logic here to set viewdata if necessary and update null parameter in selectlist with these items
        //    viewbag.directors = new selectlist(_directoryservice.query().tolist(), "ıd", "username");
        //    return view(movie);
        //}

        //// get: movies/delete/5
        //public ıactionresult delete(int id)
        //{
        //    moviemodel movie = _movieservice.query().singleordefault(u => u.id == id); // todo: add get item service logic here
        //    if (movie == null)
        //    {
        //        return notfound();
        //    }
        //    return view(movie);
        //}

        //// post: movies/delete
        //[httppost, actionname("delete")]
        //[validateantiforgerytoken]
        //public ıactionresult deleteconfirmed(int id)
        //{
        //    var result = _movieservice.deleteuser(id);
        //    tempdata["message"] = result.message;
        //    // todo: add delete service logic here
        //    return redirecttoaction(nameof(ındex));
        //}
    }
}
