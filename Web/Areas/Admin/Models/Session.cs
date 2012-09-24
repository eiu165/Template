using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.Areas.Admin.Models
{
    public class Session
    {

    }



    public class SessionDto
    { 
        public string Name { get; set; }
        public string Value { get; set; } 
        public DateTime UpdatedAt { get; set; } 
    }

}