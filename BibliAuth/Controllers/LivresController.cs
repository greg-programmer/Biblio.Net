using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliAuth.Data;
using BibliAuth.Models;
using Microsoft.AspNetCore.Authorization;
using BibliAuth.Repository;
using BibliAuth.Services;

namespace BibliAuth.Controllers
{
    public class LivresController : Controller
    {
        private readonly ApplicationDbContext _context;
        //Cette interface permet de récupérer le chemin du dossier
        private readonly IHostEnvironment _environment;
        //Cette interface permet de récupérer les méthodes de la classe Livre 
        private readonly LivreRepository _livreRepository;
        //Cette interface permet de récupérer les méthodes de la classe Auteur
        private readonly AuteurRepository _auteurRepository;
        //Cette interface permet de récupérer les méthodes de la classe Genre
        private readonly GenreRepository _genreRepository;
        private readonly LivreServices livreServices;
        //--------Emplacement qui contient toutes les variables---------//
        string notCover = "not_Cover.jpg";
        List<Livre> _livreList = new List<Livre>();
        List<Auteur> _AuteurList = new List<Auteur>();

        public LivresController(ApplicationDbContext context,
            IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _livreRepository = new LivreRepository(context);
            _auteurRepository = new AuteurRepository(context);
            _genreRepository = new GenreRepository(context);
            livreServices = new LivreServices(context);
        }



        // GET: Livres
        public async Task<IActionResult> Index()
        {
            _livreList = _livreRepository.FindAll();
            _AuteurList = _auteurRepository.FindAll();
            ViewModel viewModel = new ViewModel()
            {
                AuteurViewM = _AuteurList,
                LivreViewM = _livreList,
            };
            return View(viewModel);
        }

        // GET: Livres/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }
        [Authorize]
        // GET: Livres/Create
        public IActionResult Create()
        {
            return View();
        }
        [Authorize]
        // POST: Livres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Titre,Date_Parution,Synopsis,CheminImage,CoupDeCoeur,Id")] Livre livre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(livre);
        }

        // GET: Livres/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }
            return View(livre);
        }
        [Authorize]
        // POST: Livres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Titre,Date_Parution,Synopsis,CheminImage,CoupDeCoeur,Id")] Livre livre)
        {
            if (id != livre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivreExists(livre.Id))
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
            return View(livre);
        }
        [Authorize]
        // GET: Livres/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Livre == null)
            {
                return NotFound();
            }

            var livre = await _context.Livre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }
        [Authorize]
        // POST: Livres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Livre == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Livre'  is null.");
            }
            var livre = await _context.Livre.FindAsync(id);
            if (livre != null)
            {
                _context.Livre.Remove(livre);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(long id)
        {
          return _context.Livre.Any(e => e.Id == id);
        }
    }
}
