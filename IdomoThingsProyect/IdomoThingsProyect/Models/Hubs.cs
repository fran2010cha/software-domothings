using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdomoThingsProyect.Models
{
    public class Hubs
    {
        [Display(Name = "Ip Hub")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string HubsID { get; set; }
        public string Estado { get; set; }
        public virtual ICollection<Accion> accionhub { get; set; }

    }
}