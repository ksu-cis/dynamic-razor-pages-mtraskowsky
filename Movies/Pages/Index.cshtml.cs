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

        [BindProperty]
        /// <summary>
        /// The current search terms
        /// </summary>
        public string SearchTerms { get; set; } = "";

        [BindProperty]
        /// <summary>
        /// The filtered MPAARatings
        /// </summary>
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
        /// Gets the serach results for display on the page
        /// </summary>
        public void OnGet(double? IMDBin, double?IMDBMax)
        {
            this.IMDBin = IMDBin;
            this.IMDBMax = IMDBMax;
            Movies = MovieDatabase.Search(SearchTerms);
            Movies = MovieDatabase.FilterByMPAARating(Movies, MPAARatings);
            //Movies = MovieDatabase.FilterByGenre(Movies, Genres);
            Movies = MovieDatabase.FilterByIMDBRating(Movies, IMDBin, IMDBMax);

        }

    }
}
