using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Movies.Pages
{
    public class IndexModel : PageModel
    {
        /// <summary>
        /// The movies to display on the index page
        /// </summary>
        public IEnumerable<Movie> Movies { get; protected set; }

        /// <summary>
        /// The current search terms
        /// </summary>
        [BindProperty]
        public string SearchTerms { get; set; } = "";

        /// <summary>
        /// The filtered MPAARatings
        /// </summary>
        [BindProperty]
        public string[] MPAARatings { get; set; }

        /// <summary>
        /// The filtered genres
        /// </summary>
        [BindProperty]
        public string[] Genres { get; set; }

        /// <summary>
        /// The minimum IMDB rating
        /// </summary>
        [BindProperty]
        public double? IMDBin { get; set; }

        /// <summary>
        /// The maxiumum IMDB rating
        /// </summary>
        [BindProperty]
        public double? IMDBMax { get; set; }

        /// <summary>
        /// The Rotten tomatoes minimum filter value
        /// </summary>
        [BindProperty]
        public double? TomatoesMin { get; set; }

        /// <summary>
        /// The Rotten Tamatoes maximum filter value
        /// </summary>
        [BindProperty]
        public double? TomatoesMax { get; set; }

        /// <summary>
        /// Gets the serach results for display on the page
        /// </summary>
        public void OnGet(string SearchTerms, double? TomatoesMin)
        {
            this.SearchTerms = SearchTerms;
            this.TomatoesMin = TomatoesMin;
            Movies = MovieDatabase.All;
        }

        public void OnPost()
        {
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBin, IMDBMax);
            Movies = MovieDatabase.FilterByRottenTomatoesRating(Movies, TomatoesMin, TomatoesMax);
        }

    }
}
