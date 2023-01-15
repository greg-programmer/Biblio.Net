using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteque.Models;
using Biblioteque.Repository;

namespace Biblioteque.Controllers
{
    public class GenresController : Controller
    {
        private readonly BiblioContext _context;
        private readonly GenreRepository GenreRepository;

        public GenresController(BiblioContext context)
        {
            _context = context;
            GenreRepository = new GenreRepository(_context);
        }

        // GET: Genres
        public async Task<IActionResult> Index()
        {
              return View(GenreRepository.FindAll());
        }

        // GET: Genres/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // GET: Genres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Nom,Id")] Genre genre)
        //{
        //    if (ModelState.IsValid) //verifie que tout les champs required sont remplis 
        //    {
        //        GenreRepository.Insert(genre);
        //        GenreRepository.Commit();
        //        return RedirectToAction(nameof(Index));
        //    }
        //   return View();
        //}


        // GET: Genres/Edit/5
        public async Task<IActionResult> Edit(long id)
        {
            var genre = GenreRepository.FindById(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        // POST: Genres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Nom,Id")] Genre genre)
        {
            if (id != genre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    GenreRepository.Update(genre);
                    GenreRepository.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenreExists(genre.Id))
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
            return View(genre);
        }

        // GET: Genres/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Genres == null)
            {
                return NotFound();
            }

            var genre = await _context.Genres
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        // POST: Genres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Genres == null)
            {
                return Problem("Entity set 'BiblioContext.Genres'  is null.");
            }
            var genre = GenreRepository.FindById(id);
            if (genre != null)
            {
                GenreRepository.Delete(id);
            }

            GenreRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool GenreExists(long id)
        {
          return _context.Genres.Any(e => e.Id == id);
        }
    }
}
