using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.Noticias.Domain.Model.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Entity() 
        {
            Id = Guid.NewGuid();
        }
    }
}
