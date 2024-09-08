using Newtonsoft.Json;
using Pokedex.DAOs;
using Pokedex.Models;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonDAO _pokemonDAO;
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonService(IPokemonDAO pokemonDAO, IHttpClientFactory httpClientFactory)
        {
            _pokemonDAO = pokemonDAO;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Pokemon> GetPokemonInfoAsync(string pokemonName)
        {
            return await _pokemonDAO.GetPokemonInfoAsync(pokemonName);
        }

        public async Task<string> TranslatePokemonDescriptionAsync(Pokemon pokemon)
        {
            if (string.IsNullOrEmpty(pokemon.Description) || pokemon.Description == "Description not available")
            {
                return "Description not available for translation.";
            }

            var translationType = pokemon.IsLegendary || pokemon.Habitat.Name.ToLower() == "cave" ? "yoda" : "shakespeare";
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://api.funtranslations.com/translate/{translationType}.json?text={pokemon.Description}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var translation = JsonConvert.DeserializeObject<Translation>(content);
                return translation!.Contents.Translated;
            }

            return pokemon.Description;
        }
    }
}
