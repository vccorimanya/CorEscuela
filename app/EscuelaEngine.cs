using System;
using System.Collections.Generic;
using System.Linq;
using CorEscuela.Entidades; 

namespace CorEscuela.app
{
    public sealed class EscuelaEngine
    {
        public Escuela Escuela {get; set;}

        public EscuelaEngine(){
            Escuela = new Escuela("Ciebertec",1997,TiposEscuela.Primaria,pais:"Perú", ciudad:"Lima");
        }
       
       public void Inicializar()
        {
            Escuela = new Escuela("Ciebertec", 1997, TiposEscuela.Primaria, pais: "Perú", ciudad: "Lima");
            CargarCursos();
            CargarAsignaturas(); 
            CargarEvaluaciones();
        }

         private void CargarEvaluaciones()
        {
            foreach (var curso in Escuela.Cursos)
            {
                foreach (var asignatura in curso.Asignaturas)
                {
                    foreach (var alumno in curso.Alumnos)
                    {
                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluación()
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i +1}",
                                Nota = (float) (5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }

        public List<ObjetoEscuelaBase> GetObjetosEscuelaBase()
        {
            var listaObj = new List<ObjetoEscuelaBase>();
            listaObj.Add(Escuela);
            listaObj.AddRange(Escuela.Cursos);

            foreach (var curso in Escuela.Cursos)
            {   
                listaObj.AddRange(curso.Asignaturas);
                listaObj.AddRange(curso.Alumnos);

                foreach (var alumno in curso.Alumnos)
                {
                    listaObj.AddRange(alumno.Evaluaciones);
                }
            }

            listaObj.AddRange(Escuela.Cursos);

            return listaObj;
        }

        private void CargarAsignaturas()
        {
            foreach (var curso in Escuela.Cursos)
            {
                List<Asignatura> listaAsignaturas = new List<Asignatura>()
                {
                    new Asignatura(){Nombre="Matemática"},
                    new Asignatura(){Nombre = "Educación Física"},
                    new Asignatura(){Nombre="Castellano"},
                    new Asignatura(){Nombre="Ciencias Naturales"},
                    new Asignatura(){Nombre="DBA2"}
                };
                curso.Asignaturas = listaAsignaturas;
            }
        }

        private List<Alumno> GenetarAlumnosAlAzar(int cantidad)
        {
            string[] nombre1 = {"Alba", "Felipa", "Eusebio", "Farid", "Donald", "Alvaro", "Nicolás"};
            string[] apellido1 = {"Ruiz", "Sarmiento", "Uribe", "Maduro", "Trump", "Toledo", "Herrera"};
            string[] nombre2 = {"Freddy", "Anabel", "Rick", "Murty", "Silvana", "Diomedes", "Nicomedes", "Teodoro"};

            var listaAlumnos = from n1 in nombre1
                               from n2 in nombre2
                               from a1 in apellido1
                               select new Alumno{Nombre=$"{n1} {n2} {a1}"};
            return listaAlumnos.OrderBy((al) => al.UniqueId ).Take(cantidad).ToList();
        }


        private void CargarCursos()
        {
            Escuela.Cursos = new List<Curso>(){
                new Curso(){Nombre="101", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre="301", Jornada = TiposJornada.Mañana},
                new Curso(){Nombre="401", Jornada = TiposJornada.Tarde},
                new Curso(){Nombre="501", Jornada = TiposJornada.Tarde}
            };

            Random rnd = new Random();
            foreach (var c in Escuela.Cursos)
            {
                int cantRandom = rnd.Next(5,20);
                c.Alumnos = GenetarAlumnosAlAzar(cantRandom);
            }
        }
    }
}