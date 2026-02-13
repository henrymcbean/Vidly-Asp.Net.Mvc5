using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_Asp.Net.Mvc5.Models;

namespace Vidly_Asp.Net.Mvc5.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}