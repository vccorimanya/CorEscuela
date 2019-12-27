using System;
using System.Collections.Generic;

namespace CorEscuela.Entidades
{  
    public class Escuela
    {
        public string UniqueId {get; set; } = Guid.NewGuid().ToString();
        private string nombre;
        public string Nombre
        {
             get{return "Copia_" + nombre;}
             set{nombre = value.ToUpper();}
         }
        public string Direccion {get; set;}
        public int AñoDeCreacion {get;set;}
        public string Pais { get; set; }
        public string Ciudad { get; set; }
        public TiposEscuela TipoEscuela {get; set;}
        public List<Curso> Cursos {get;set;}
        
        public Escuela(string nombre, int año) => (Nombre,AñoDeCreacion) = (nombre, año);
        public Escuela(string nombre, int año, TiposEscuela tipos, string pais="", string ciudad ="")
        {
            (Nombre, AñoDeCreacion) = (nombre, año);
            Pais = pais;
            Ciudad = ciudad;
        }

        //Sobreescribiendo el objeto ToString 
        public override string ToString()
        {
            return $"Nombre: {Nombre}, Tipo: {TipoEscuela}, \n Pais: {Pais}, Ciudad: {Ciudad}";
        }
    }
}