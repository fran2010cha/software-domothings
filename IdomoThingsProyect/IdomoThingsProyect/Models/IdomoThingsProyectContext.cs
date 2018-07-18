using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdomoThingsProyect.Models
{
    public class IdomoThingsProyectContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IdomoThingsProyectContext() : base("name=IdomoThingsProyectContext")
        {
        }

        public System.Data.Entity.DbSet<IdomoThingsProyect.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<IdomoThingsProyect.Models.Hubs> Hubs { get; set; }

        public System.Data.Entity.DbSet<IdomoThingsProyect.Models.Accion> Accions { get; set; }
    }
}
