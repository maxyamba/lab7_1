
namespace Mvc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class mvcCitiesModel
    {
        [Key]
        public int id_city { get; set; }

        [Required]
        [StringLength(30)]
        public string city { get; set; }

        public int? Country_id_country { get; set; }

        public virtual Countries Countries { get; set; }
        public virtual ICollection<Cinemas> Cinemas { get; set; }
    }
}