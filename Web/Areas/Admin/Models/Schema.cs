using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Massive;

namespace Web.Areas.Admin.Models
{ 

    public class Schema : DynamicModel
    {
        public Schema()
            : base("DefaultConnection", "[Schema]", "Id")
        {
        }
    }


    public class SchemaDto
    {
        public int Id { get; set; }
        public long Version { get; set; }
        public DateTime UtcDate { get; set; }
        public string BuildNumber { get; set; }
        public string Status { get; set; } 
        public DateTime UpdatedAt { get; set; }
        public string UpdatedAtString { get; set; }
    } 
}


/*
	[Id] [int] IDENTITY(1, 1) NOT NULL , 
	[Version] [bigint] NOT NULL,
	[UtcDate]  [datetime] DEFAULT (GETUTCDATE()),
	[BuildNumber] [nvarchar](100)  , 
	[Status] [nvarchar](50) NULL ,
	[CreatedAt] [datetime] not null default(getdate()) ,
	[UpdatedAt] [datetime]  not null default(getdate())  */