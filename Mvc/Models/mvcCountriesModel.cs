
namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Infrastructure;

    public class mvcCountriesModel
    {
        

        [Key]
        public int id_country { get; set; }

        [Required(ErrorMessage ="Field is required")]
        [StringLength(30)]
        public string country { get; set; }

        
    }
}