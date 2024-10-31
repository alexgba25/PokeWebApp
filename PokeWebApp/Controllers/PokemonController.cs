using Microsoft.AspNetCore.Mvc;
using PokeWebApp.Services;

namespace PokeWebApp.Controllers
{
    public class PokemonController : Controller
    {
        // Paso 5: Controller

        private readonly PokeApiService _pokeApiService;

        public PokemonController(PokeApiService pokeApiService)
        {
            _pokeApiService = pokeApiService;
        }

        public async Task<IActionResult> Index(string searchTerm, int? page)
        {
            var pokemonList = await _pokeApiService.GetFirstPokemonAsync(151); 
            if (!string.IsNullOrEmpty(searchTerm))
            {
                pokemonList = pokemonList
                    .Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            int pageSize = 5; 
            int pageNumber = page ?? 1; 

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageCount = (int)Math.Ceiling((double)pokemonList.Count / pageSize);

            var pagedList = pokemonList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            ViewData["CurrentFilter"] = searchTerm;

            return View(pagedList);
        }
    }
}
