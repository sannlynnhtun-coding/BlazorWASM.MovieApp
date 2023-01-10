using BlazorWASM.MovieApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorWASM.MovieApp.Services
{
    public class MovieApi
    {
        private readonly HttpClient _httpClient;

        public MovieApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SearchModel> Search(string movieName)
        {
            SearchModel model = new();
            string endpoints = $"?s={movieName}&apikey=da979bab&action=opensearch&format=json&origin=*&search={movieName}";
            var response = await _httpClient.GetAsync(endpoints);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<SearchModel>(jsonStr);
                model = model ?? new SearchModel();
                model.IsSuccess = true;
            }
            return model;
        }

        public async Task<DetailModel> Detail(string movieId)
        {
            DetailModel model = new();
            string endpoints = $"?i={movieId}&apikey=da979bab&action=opensearch&format=json&origin=*&search={movieId}";
            var response = await _httpClient.GetAsync(endpoints);
            if (response.IsSuccessStatusCode)
            {
                var jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<DetailModel>(jsonStr);
                model = model ?? new DetailModel();
                model.IsSuccess = true;
            }
            return model;
        }
    }
}
