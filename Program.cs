using CorEscuela.app;
using CorEscuela.Entidades;
using CorEscuela.util;

namespace CorEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new EscuelaEngine();
            engine.Inicializar();
            Printer.WriteTitle("Bienbenidos a la escuela");
            ImprimirCursosEscuela(engine.Escuela);

            var listaObjetos = engine.GetObjetosEscuelaBase();
        }



        ///summary
        ///Este método sirve para validar que la escuela exista, la escuela tenga cursos
        ///y solo así se imprimrán los cursos que tiene
        ///
        private static void ImprimirCursosEscuela(Escuela escuela)
        {   
            
            Printer.WriteTitle("Cursos escuela");
            
            if(escuela?.Cursos != null){
                foreach (var curso in escuela.Cursos)
                {                    
                    System.Console.WriteLine($"Nombre: {curso.Nombre}, Id: {curso.UniqueId}");
                }
            }
        }
    }
}
