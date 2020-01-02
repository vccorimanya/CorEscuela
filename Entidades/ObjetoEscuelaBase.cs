using System;

namespace CorEscuela.Entidades
{
    public abstract class ObjetoEscuelaBase
    {
        public string UniqueId { get; set; } /* = Guid.NewGuid().ToString(); */
        public string Nombre { get; set;}

        public ObjetoEscuelaBase(){
            UniqueId = Guid.NewGuid().ToString();
        }
    }
}