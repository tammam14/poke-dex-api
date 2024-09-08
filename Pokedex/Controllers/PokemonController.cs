using Microsoft.AspNetCore.Mvc;
using Pokedex.Services;

namespace Pokedex.Controllers
{

        [ApiController]
        [Route("api/pokemon")]
        public class PokemonController : ControllerBase
        {
            private readonly IPokemonService _pokemonService;

            public PokemonController(IPokemonService pokemonService)
            {
                _pokemonService = pokemonService;
            }

            [HttpGet("{name}")]
            public async Task<IActionResult> GetPokemon(string name)
            {
                var pokemon = await _pokemonService.GetPokemonInfoAsync(name);
                if (pokemon == null)
                {
                    return NotFound(new { message = "Pokémon not found" });
                }
                return Ok(pokemon);
            }

            [HttpGet("translated/{name}")]
            public async Task<IActionResult> GetTranslatedPokemon(string name)
            {
                var pokemon = await _pokemonService.GetPokemonInfoAsync(name);
                if (pokemon == null)
                {
                    return NotFound(new { message = "Pokémon not found" });
                }

                var translatedDescription = await _pokemonService.TranslatePokemonDescriptionAsync(pokemon);
                pokemon.Description = translatedDescription;
                return Ok(pokemon);
            }
        }
    
}
