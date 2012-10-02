using Massive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Models
{
    public class Movie : DynamicModel
    {
        public Movie()
            : base("DefaultConnection", "Movie", "Id")
        {
        }
    }
}