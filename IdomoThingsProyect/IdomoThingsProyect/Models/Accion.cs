using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IdomoThingsProyect.Models
{
    public class Accion
    {
        [Key]
        public int AccionID { get; set; }
        public string AccionHecha { get; set; }
        public int UsuarioId { get; set; }
        public string HubsID { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Hubs hubs { get; set; }

    }
}