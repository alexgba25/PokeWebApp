using Newtonsoft.Json;
using PokeWebApp.Models;
using System.Text.Json.Serialization;

namespace PokeWebApp.Services
{
    public class PokeApiService
    {
        // Paso 4: Services(Clase)

        private readonly HttpClient _httpClient;

        public PokeApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Pokemon>> GetFirstPokemonAsync(int count)
        {
            var response = await _httpClient.GetAsync($"https://localhost:7033/api/pokemon?count={count}");
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var pokemonList = JsonConvert.DeserializeObject<List<Pokemon>>(data);
            return pokemonList;
        }
    }
}
