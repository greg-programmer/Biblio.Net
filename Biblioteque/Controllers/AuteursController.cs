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
    public class AuteursController : Controller
    {
        private readonly BiblioContext _context;
        private readonly AuteurRepository auteurRepository;

        public AuteursController(BiblioContext context)
        {
            _context = context;
            auteurRepository = new AuteurRepository(context);
        }

        // GET: Auteurs
        //public async Task<IActionResult> Index()
        //{
        //      return View(auteurRepository.FindAll());
        //}

        // GET: Auteurs/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auteur == null)
            {
                return NotFound();
            }

            return View(auteur);
        }

        // GET: Auteurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auteurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Nom,Prenom,Date_Naissance,Date_Mort,Id")] Auteur auteur)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        auteurRepository.Insert(auteur);
        //        auteurRepository.Commit();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(auteur);
        //}

        // GET: Auteurs/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return NotFound();
            }
            return View(auteur);
        }

        // POST: Auteurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Nom,Prenom,Date_Naissance,Date_Mort,Id")] Auteur auteur)
        {
            if (id != auteur.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  auteurRepository.Update(auteur);
                  auteurRepository.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuteurExists(auteur.Id))
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
            return View(auteur);
        }

        // GET: Auteurs/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Auteurs == null)
            {
                return NotFound();
            }

            var auteur = await _context.Auteurs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (auteur == null)
            {
                return NotFound();
            }

            return View(auteur);
        }

        // POST: Auteurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Auteurs == null)
            {
                return Problem("Entity set 'BiblioContext.Auteurs'  is null.");
            }
            var auteur = auteurRepository.FindById(id);
            if (auteur != null)
            {
                auteurRepository.Delete(id);
            }

            auteurRepository.Commit();
            return RedirectToAction(nameof(Index));
        }

        private bool AuteurExists(long id)
        {
          return _context.Auteurs.Any(e => e.Id == id);
        }
    }
}
