﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZenithDataLib.Models
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }

        [Required]
        [Display(Name = "Activity Description")]
        [MaxLength(40, ErrorMessage = "The {0} cannot exceed {1} characters long.")]
        public string ActivityDescription { get; set; }

        [Display(Name = "Creation Date")]
        [DisplayFormat(DataFormatString = "{0:MM'/'dd'/'yyyy hh:mm tt}")]
        public DateTime CreationDate { get;  set;}

        public List<Event> Events { get; set; }
    }
}
