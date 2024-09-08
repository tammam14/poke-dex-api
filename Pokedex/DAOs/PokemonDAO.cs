using Newtonsoft.Json.Linq;
using Pokedex.Models;

namespace Pokedex.DAOs
{
    public class PokemonDAO : IPokemonDAO
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PokemonDAO(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Pokemon> GetPokemonInfoAsync(string pokemonName)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://pokeapi.co/api/v2/pokemon-species/{pokemonName}");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pokemonData = JObject.Parse(json);

                var pokemon = new Pokemon
                {
                    Name = pokemonData["name"].ToString(),
                    IsLegendary = pokemonData["is_legendary"].ToObject<bool>(),
                    Habitat = pokemonData["habitat"] != null
                        ? new Habitat { Name = pokemonData["habitat"]["name"].ToString() }
                        : new Habitat { Name = "unknown" }
                };

                var flavorTextEntries = pokemonData["flavor_text_entries"];
                if (flavorTextEntries != null)
                {
                    foreach (var entry in flavorTextEntries)
                    {
                        if (entry["language"]["name"].ToString() == "en")
                        {
                            var flavorText = entry["flavor_text"].ToString();

                            if (!string.IsNullOrEmpty(flavorText))
                            {
                                pokemon.Description = flavorText.Replace("\n", " ").Replace("\f", " ");
                            }
                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(pokemon.Description))
                {
                    pokemon.Description = "Description not available";
                }

                return pokemon;
            }

            return null;
        }
    }

}
