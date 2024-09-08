using Pokedex.Models;

namespace Pokedex.Services
{
    public interface IPokemonService
    {
        Task<Pokemon> GetPokemonInfoAsync(string pokemonName);
        Task<string> TranslatePokemonDescriptionAsync(Pokemon pokemon);
    }
}
