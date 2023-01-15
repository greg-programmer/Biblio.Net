using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteque.Models;
using Biblioteque.Repository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Hosting;
using System.Drawing;
using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging.Signing;
using Biblioteque.Migrations;
using NuGet.ContentModel;
using Microsoft.AspNetCore.Components.Forms;
using Biblioteque.Services;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

namespace Biblioteque.Controllers
{
    public class LivresController : Controller
    {
        //BiblioContext contient toute la Bdd
        private readonly BiblioContext _context;
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

        public LivresController(BiblioContext context, IHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _livreRepository = new LivreRepository(context);
            _auteurRepository = new AuteurRepository(context);
            _genreRepository = new GenreRepository(context);
            livreServices = new LivreServices(context);
        }

        // GET: Livres1
        public async Task<IActionResult> Index()        {
           
            _livreList = _livreRepository.FindAll();
            _AuteurList = _auteurRepository.FindAll();  
            ViewModel viewModel = new ViewModel()
            {
                AuteurViewM = _AuteurList,
                LivreViewM = _livreList,
            };    
            return View(viewModel);
        }

        // GET: Livres1/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _livreList == null)
            {
                return NotFound();
            }
         
           var livre =  _livreRepository.FindById(id.Value);
            var auteur = _auteurRepository.FindById(id.Value);
            var genre = _genreRepository.FindById(id.Value);
            var livreList = _livreRepository.FindAll();

            if (livre == null)
            {
                return NotFound();
            }

           if(livre.Id != auteur.LivreId)
            {
                return NotFound();  
            }
            ViewModel viewModel = new ViewModel
            {
                AuteurViewM_Nolist = auteur,
                LivreViewM_Nolist = livre,
                GenreViewM_Nolist = genre,
                LivreViewM = livreList
            };

            return View(viewModel);            
        }

        // GET: Livres1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Livres1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModel viewModel,bool heart)
        {           
                try
                {
                if (viewModel.LivreViewM_Nolist.Image.Length > 1000)
                {

                    return RedirectToAction(nameof(MaxFile));    
                   
                }
                _livreRepository.GetFilesPath(viewModel);           
                }
                catch
                {
                    viewModel.LivreViewM_Nolist.CheminImage = notCover;
                }
                _livreRepository.Insert(viewModel.LivreViewM_Nolist);
                _auteurRepository.Insert(viewModel.AuteurViewM_Nolist); 
                _genreRepository.Insert(viewModel.GenreViewM_Nolist);
                _livreRepository.Commit();
                _genreRepository.Commit();
                _auteurRepository.Commit();
                //Récupération de l'Id automatique du livre
                await _context.SaveChangesAsync(); 
                //Initalisation de livreId de Auteur avec l'Id récupéré du livre
                viewModel.AuteurViewM_Nolist.LivreId = viewModel.LivreViewM_Nolist.Id;
                //Initalisation de livreId de Genre avec l'Id récupéré du livre
                viewModel.GenreViewM_Nolist.LivreId = viewModel.LivreViewM_Nolist.Id;
                var livreList =_livreRepository.FindAll();
                livreServices.FavoriteBook(heart, livreList, viewModel.LivreViewM_Nolist.Id);
                await _context.SaveChangesAsync();              
                return RedirectToAction(nameof(Index));                    
            
            return View(viewModel);            
        }

        public IActionResult MaxFile()
        {
            return View();
        }

        // GET: Livres1/Edit/5
        public async Task<IActionResult> Edit(long? id)        {

            if (id == null || _livreList == null)
            {
                return NotFound();
            }
            var livre = _livreRepository.FindById(id.Value);
            var auteur = _auteurRepository.FindById(id.Value);
            var genre = _genreRepository.FindById(id.Value);
            var livreList = _livreRepository.FindAll();

            if (livre == null)
            {
                return NotFound();
            }

            if (livre.Id != auteur.LivreId)
            {
                return NotFound();
            }

            ViewModel viewModel = new ViewModel
            {
                AuteurViewM_Nolist = auteur,
                LivreViewM_Nolist = livre,
                GenreViewM_Nolist = genre,
                LivreViewM = livreList,
            };          

            return View(viewModel);

        }    

        // POST: Livres1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, ViewModel viewModel, bool heart)
        
        {
            var livre = _livreRepository.FindById(id);
            var auteur = _auteurRepository.FindById(id);
            var genre = _genreRepository.FindById(id);
            var livreList = _livreRepository.FindAll();


            if (livre == null)
            {
                return NotFound();
            }

         
            
                try
                {
                    _livreRepository.GetFilesPath(viewModel);
                    //Appel de la méthode GetfilesPath() pour récuperer le chemin du nouveau fichier 
                   if (viewModel.LivreViewM_Nolist.CheminImage != null)
                    {
                        _livreRepository.DeleteImage(livre.CheminImage);
                    }
                    //Appel de la méthode DeleteImage() pour supprimer l'ancienne image               
                }
                catch
                {
                    if(livre.CheminImage != notCover)
                    {
                        viewModel.LivreViewM_Nolist.CheminImage = livre.CheminImage;
                    }
                    else
                    {
                        viewModel.LivreViewM_Nolist.CheminImage = notCover;
                    }                    
                }
                if (heart)
                {
                    livreServices.FavoriteBook(heart, livreList, id);
                }
                else
                {
                    livre.CoupDeCoeur = heart;
                }

                if (livre.Id == auteur.LivreId && livre.Id == genre.LivreId)
                {
                    livre.Titre = viewModel.LivreViewM_Nolist.Titre; 
                    livre.Date_Parution = viewModel.LivreViewM_Nolist.Date_Parution;
                    if(viewModel.LivreViewM_Nolist.Image == null)
                    {
                        viewModel.LivreViewM_Nolist.CheminImage = livre.CheminImage;
                    }
                    else
                    {
                        livre.CheminImage = viewModel.LivreViewM_Nolist.CheminImage;
                    }                  
                    livre.Synopsis = viewModel.LivreViewM_Nolist.Synopsis;
                    _context.Livres.Update(livre);
                    auteur.Prenom = viewModel.AuteurViewM_Nolist.Prenom;
                    auteur.Nom = viewModel.AuteurViewM_Nolist.Nom;                    
                    _context.Auteurs.Update(auteur);
                    genre.Nom = viewModel.GenreViewM_Nolist.Nom;
                    _context.Genres.Update(genre);
                     await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
             
            
            return View(viewModel);
        }

        // GET: Livres1/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _livreList == null)
            {
                return NotFound();
            }

            var livre = _livreRepository.FindById(id.Value);
            if (livre == null)
            {
                return NotFound();
            }

            return View(livre);
        }
        //GET : Image/delete
        public async Task<IActionResult> DeleteImageConfirmed(long id)
        {
            var livre = _livreRepository.FindById(id);
            if (livre == null)
            {
                return NotFound();
            }
            return View(livre);
        }
        [HttpPost, ActionName("DeleteImageConfirmedPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_livreList == null)
            {
                return Problem("Le livre n'existe pas!");
            }
            var livre = await _context.Livres.FindAsync(id);          
          

            if (livre != null && livre.CheminImage != null)
            {
                _livreRepository.DeleteImage(livre.CheminImage);             
            }

            livre.CheminImage = notCover;
            //_context.Genres.Remove(genre);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Livres1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmedImage(long id)
        {
            if (_context.Livres == null)
            {
                return Problem("Le livre n'existe pas!");
            }
            var livre = _livreRepository.FindById(id);
            var auteur = _auteurRepository.FindById(id);
            var genre = _genreRepository.FindById(id);
            var livreList = _livreRepository.FindAll();

            if (livre != null && livre.CheminImage != null)
            {
                _livreRepository.DeleteImage(livre.CheminImage);                                        
            }
           
            _context.Livres.Remove(livre);
            _context.Auteurs.Remove(auteur);
            _context.Genres.Remove(genre);
            //_context.Genres.Remove(genre);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivreExists(long id)
        {
          return _context.Livres.Any(e => e.Id == id);
        }
    }
}
