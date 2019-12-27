using static System.Console;

namespace CorEscuela
{
    public static class Printer
    {
        public static void DibujarLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DibujarLinea(tamaño);
            WriteLine($"| {titulo} |");
            DibujarLinea(tamaño);

        }

       public static void Sonar(int hz, int tiempo, int cantidad){
           while (cantidad-- > 0)
           {
               System.Console.Beep();
           }
       }
    }
}