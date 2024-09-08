using Pokedex.Models;

namespace Pokedex.DAOs
{
    public interface IPokemonDAO
    {
        Task<Pokemon> GetPokemonInfoAsync(string pokemonName);
    }
}
