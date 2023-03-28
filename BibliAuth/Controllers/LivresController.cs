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
using BibliAuth.Data.Migrations;
using NuGet.Protocol.Core.Types;

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
        List<Genre> _genreList = new List<Genre>(); 
        string admin = "gregory.schoemaecker@adminbookin.fr";


            public LivresController(ApplicationDbContext context, IHostEnvironment environment)
            {
                _context = context;
                _environment = environment;
                _livreRepository = new LivreRepository(context);
                _auteurRepository = new AuteurRepository(context);
                _genreRepository = new GenreRepository(context);
                livreServices = new LivreServices(context);
            
            }

            // GET: Livres1
            public async Task<IActionResult> Index(long id)
            {
            var livreList = _livreRepository.FindAll();
            var auteurList = _auteurRepository.FindAll();
            var genreList = _genreRepository.FindAll();
            var q = (from pd in genreList
                     join od in _context.Livre on pd.LivreId equals od.Id
                     join ad in _context.Auteur on pd.LivreId equals ad.LivreId
                     orderby od.Id
                     select new ViewModel()
                     {
                         LivreViewM_Nolist = od,
                         AuteurViewM_Nolist = ad,
                         GenreViewM_Nolist = pd,
                     }).ToList();
            q.Reverse();
            return View(q);
        }
        //Home pour la première page//
        public IActionResult Home()
        {
            _livreList = _livreRepository.FindAll();
            long firstId = _livreList[0].Id;
            _AuteurList = _auteurRepository.FindAll();
            _genreList = _genreRepository.FindAll();
            var auteur = _auteurRepository.FindById(firstId);
            var genre = _genreRepository.FindById(firstId);
            ViewModel viewModel = new ViewModel()
            {
                AuteurViewM = _AuteurList,
                LivreViewM = _livreList,
                GenreViewM = _genreList,
                AuteurViewM_Nolist = auteur,
                GenreViewM_Nolist = genre
            };
            return View(viewModel);
        }
        // GET: Récupère les livres recherchés
        public async Task<IActionResult> inputSearch(string value)
        {
            
            _livreList = livreServices.InputSearch(value);
            var q = (from pd in _livreList
                     join od in _context.Auteur on pd.Id equals od.LivreId
                     join ad in _context.Genre on pd.Id equals ad.LivreId
                     orderby od.LivreId
                     select new ViewModel()
                     {
                         LivreViewM_Nolist = pd,
                         AuteurViewM_Nolist = od,
                         GenreViewM_Nolist = ad,
                     }).ToList();


            if ( q.Count() == 0)
            {
                return RedirectToAction(nameof(Error404BookNotFound));
            }       
            return View(q);
        }
        //Il s'agit de la requête pour filtrer les livres par genre/
        public async Task<IActionResult> RomanFilter(string value)
        {
            var GenreList = _genreRepository.FindAll();
            var GenrelistRoman = GenreList.Where(b => b.Nom == "Roman").ToList();
            var q = (from pd in GenrelistRoman
                     join od in _context.Livre on pd.LivreId equals od.Id
                     join ad in _context.Auteur on pd.LivreId equals ad.LivreId
                     orderby od.Id
                     select new ViewModel()
                     {
                         LivreViewM_Nolist = od,
                         AuteurViewM_Nolist = ad,
                         GenreViewM_Nolist = pd,
                     }).ToList();
            return View(q);
        }
        //Affiche livre non trouvé//
        public async Task<IActionResult>Error404BookNotFound ()
        {     
            return View();
        }

        // GET: Livres1/Details/5
        public async Task<IActionResult> Details(long? id)
            {
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
                    LivreViewM = livreList
                };

                return View(viewModel);
            }
        
            // GET: Livres1/Create
            public IActionResult Create()
            {
            if(User.Identity.Name == admin)
            {
                _livreList = _livreRepository.FindAll();
                _AuteurList = _auteurRepository.FindAll();
                _genreList = _genreRepository.FindAll();
                ViewModel viewModel = new ViewModel()
                {
                    AuteurViewM = _AuteurList,
                    LivreViewM = _livreList,
                    GenreViewM = _genreList,
                };
                return View(viewModel);
            }
            else
            {
                return BadRequest();
            }  
            
        } 
           

            // POST: Livres1/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(ViewModel viewModel, bool heart)
            {
            if (User.Identity.Name == admin)
            {
                try
                {
                    if (viewModel.LivreViewM_Nolist.Image.Length > 1000000)
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
                var livreList = _livreRepository.FindAll();
                livreServices.FavoriteBook(heart, livreList, viewModel.LivreViewM_Nolist.Id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
                           
            }

            public IActionResult MaxFile()
            {
                return View();
            }

            // GET: Livres1/Edit/5
            public async Task<IActionResult> Edit(long? id)
            {
               if(User.Identity.Name == admin)
            {
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
            else
            {
                return PartialView("../Home/_LoginPartial.cshtml");
            }
            }

            // POST: Livres1/Edit/5
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(long id, ViewModel viewModel, bool heart)

            {
                if(User.Identity.Name == admin)
            {
                if (id == null || _livreList == null)
                {
                    return NotFound();
                }
                var livre = _livreRepository.FindById(id);
                var auteur = _auteurRepository.FindById(id);
                var genre = _genreRepository.FindById(id);
                var livreList = _livreRepository.FindAll();

                if (livre == null)
                {
                    return NotFound();
                }

                if (livre.Id != auteur.LivreId)
                {
                    return NotFound();
                }

                livreServices.FavoriteBook(heart, livreList, livre.Id);

                //J'ai mis à jour toutes les propriétés de l'objet livre //
                livre.Titre = viewModel.LivreViewM_Nolist.Titre;
                livre.Date_Parution = viewModel.LivreViewM_Nolist.Date_Parution;
                livre.CoupDeCoeur = heart;
                livre.Synopsis = viewModel.LivreViewM_Nolist.Synopsis;
                //Comme il peut y à avoir des exceptions pour la gestion du fichier image, je créé le bloc 'try'//
                try
                {
                    string wwwRootPath = Environment.CurrentDirectory;
                    string fileName = Path.GetFileNameWithoutExtension(path: viewModel.LivreViewM_Nolist.Image.FileName);
                    string extension = Path.GetExtension(viewModel.LivreViewM_Nolist.Image.FileName);
                    long sizeFile = viewModel.LivreViewM_Nolist.Image.Length;
                    Console.WriteLine(sizeFile);
                    viewModel.LivreViewM_Nolist.CheminImage = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    string path = Path.Combine(wwwRootPath, "wwwroot", "Upload", fileName);
                    Console.WriteLine(sizeFile);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {

                       await viewModel.LivreViewM_Nolist.Image.CopyToAsync(stream);
                    }
                    livre.CheminImage = viewModel.LivreViewM_Nolist.CheminImage;
                }
                catch
                {
                    Console.WriteLine("L'image reste la même!"); 
                }
                //J'ai mis à jour toutes les propriétés de l'objet Auteur//
                auteur.Nom = viewModel.AuteurViewM_Nolist.Nom;
                auteur.Prenom = viewModel.AuteurViewM_Nolist.Prenom;
                auteur.Date_Naissance = viewModel.AuteurViewM_Nolist.Date_Naissance;
                auteur.Date_Mort = viewModel.AuteurViewM_Nolist.Date_Mort;
                //J'ai mis à jour toutes les propriétés de l'objet Genre//
                genre.Nom = viewModel.GenreViewM_Nolist.Nom;
                //Enfin, je sauvegarde les changements dans la BDD//
                _context.SaveChanges();        
                //Je retourne à la page d'accueil//
                return RedirectToAction(nameof(Home));               
            }
            else
            {
                return NotFound();
            }          
             
            }

            // GET: Livres1/Delete/5
            public async Task<IActionResult> Delete(long? id)
            {
            if (User.Identity.Name == admin)
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
            else
            {
                return NotFound();
            }             
            }
            //GET : Image/delete
            public async Task<IActionResult> DeleteImageConfirmed(long id)
            {
            if (User.Identity.Name == admin)
            {
                var livre = _livreRepository.FindById(id);
                if (livre == null)
                {
                    return NotFound();
                }
                return View(livre);
            }
            else
            {
                return NotFound();
            }            
            }
            [HttpPost, ActionName("DeleteImageConfirmedPost")]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> DeleteConfirmed(long id)
            {
                if (_livreList == null)
                {
                    return Problem("Le livre n'existe pas!");
                }
                var livre = await _context.Livre.FindAsync(id);


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
                if (_context.Livre == null)
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

                _context.Livre.Remove(livre);
                _context.Auteur.Remove(auteur);
                _context.Genre.Remove(genre);
                //_context.Genres.Remove(genre);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            private bool LivreExists(long id)
            {
                return _context.Livre.Any(e => e.Id == id);
            }
        }
    }
