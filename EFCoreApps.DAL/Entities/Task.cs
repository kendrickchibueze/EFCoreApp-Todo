﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace EFCoreApps.DAL.Entities
{


    [Index(nameof(Name), nameof(Description), Name = "IX_Task_Name")]
    public class Task:BaseEntity
    {

        [Required, StringLength(50, ErrorMessage = "Name shouldn't be longer than fifty characters")]

        public string Name { get; set; }

        [Required, StringLength(300, ErrorMessage = "Description can't be too long")]
        public string Description { get; set; }

        public bool IsCompleted{ get; set; }

        public int UserId { get; set; }

        public User User{ get; set; }

        public IEnumerable<Tag> Tags { get; set; } = new List<Tag>();
    }
}
