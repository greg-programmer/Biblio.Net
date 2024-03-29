﻿using BibliAuth.Data;
using BibliAuth.Models;
using BibliAuth.Repository;
using BibliAuth.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BibliAuth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;
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
        List<Genre> _GenreList = new List<Genre>();

        public HomeController(ApplicationDbContext context,
            ILogger<HomeController> logger, 
            IHostEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _environment = environment;
            _livreRepository = new LivreRepository(context);
            _auteurRepository = new AuteurRepository(context);
            _genreRepository = new GenreRepository(context);            
            livreServices = new LivreServices(context);
        }

        public IActionResult Home( long test )
        {
             _livreList = _livreRepository.FindAll();
            long firstId = _livreList[0].Id;            
            _AuteurList = _auteurRepository.FindAll();
            _GenreList = _genreRepository.FindAll();
            var auteur = _auteurRepository.FindById(firstId);
            var genre = _genreRepository.FindById(firstId);
            ViewModel viewModel = new ViewModel()
            {
                AuteurViewM = _AuteurList,
                LivreViewM = _livreList,
                GenreViewM = _GenreList,   
                AuteurViewM_Nolist = auteur,
                GenreViewM_Nolist = genre
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}