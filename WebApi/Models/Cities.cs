namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cities
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cities()
        {
            Cinemas = new HashSet<Cinemas>();
        }

        [Key]
        public int id_city { get; set; }

        [Required]
        [StringLength(30)]
        public string city { get; set; }

        public int? Country_id_country { get; set; }

        public virtual Countries Countries { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cinemas> Cinemas { get; set; }
    }
}
