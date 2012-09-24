using System;
using Massive;

namespace Application.Models
{
    public class Log : DynamicModel
    {
        public Log()
            : base("DefaultConnection", "Log", "ID")
        {
        }
    }


    public class LogDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public string Level { get; set; }
        public string IpAddress { get; set; }
        public string Server { get; set; }
        public string Session { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string UpdatedAtString { get; set; }
    }

}