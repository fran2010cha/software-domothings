using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IdomoThingsProyect.Models
{
    public class Usuario
    {
        [DisplayName("Codigo Usuario")]
        [Required(ErrorMessage = "deve ser requerido el Codigo ")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public virtual ICollection<Accion> accionhub { get; set; }

    }
}