using BlazorWASM.MovieApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASM.MovieApp.Pages
{
    public partial class MovieApp
    {
        private string MovieName { get; set; }
        private bool ShowDetail { get; set; } = false;

        private SearchModel model = new SearchModel();
        private DetailModel detailModel = new DetailModel();

        protected override async Task OnInitializedAsync()
        {

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {

            }
        }

        async Task Search()
        {
            await GetMovie(MovieName);
        }

        async Task GetMovie(string movieName)
        {
            model = await _movieApi.Search(movieName);
        }

        async Task Detail(string movieId)
        {
            detailModel = await _movieApi.Detail(movieId);
            ShowDetail = true;
        }

        void Back()
        {
            ShowDetail = false;
        }
    }
}
