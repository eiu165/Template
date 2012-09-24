using System;
using Massive;

namespace Application.Models
{
    public class Config : DynamicModel
    {
        public Config()
            : base("ApplicationConnectionString", "Config", "ID")
        {
        }
    }





    public class ConfigDto
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public DateTime UpdatedAt { get; set; } 
    }


}