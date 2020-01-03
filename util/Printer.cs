using static System.Console;

namespace CorEscuela.util
{
    public static class Printer
    {
        public static void DrawLinea(int tam = 10)
        {
            WriteLine("".PadLeft(tam,'='));
        }

        public static void WriteTitle(string titulo)
        {
            var tamaño = titulo.Length + 4;
            DrawLinea(tamaño);
            WriteLine($"| {titulo} |");
            DrawLinea(tamaño);

        }

       public static void Sonar(int hz, int tiempo, int cantidad){
           while (cantidad-- > 0)
           {
               System.Console.Beep();
           }
       }
    }
}