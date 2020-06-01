using System;

namespace IEU
{
    public class Program
    {
        public unsafe static void Main()
        {
            Alumno[] alumnos =
            {
            new Alumno() { Id = 1,  Nombre = "Ana Amado", Edad = 10, Matematicas = 8.5f, Espanol = 9.0f, Quimica = 7.5f, Fisica = 8.0f },
            new Alumno() { Id = 2, Nombre = "Bernardo Barcenas" , Edad = 11, Matematicas= 7f, Espanol = 8.5f, Quimica = 9.5f, Fisica = 9.0f },
            new Alumno() { Id = 3, Nombre = "Carlos Corrales" , Edad = 9, Matematicas= 8.0f, Espanol = 9.5f, Quimica = 8.5f, Fisica = 8.0f },
            new Alumno() { Id = 4, Nombre = "Daniel Duval" , Edad = 10, Matematicas= 6.0f, Espanol = 10f, Quimica = 9.0f, Fisica = 7.0f },
            new Alumno() { Id = 5, Nombre = "Ernesto Egea" , Edad = 8, Matematicas= 7.5f, Espanol = 9f, Quimica = 8.0f, Fisica = 6.0f },
            new Alumno() { Id = 6, Nombre = "Fernando Fajardo" , Edad = 9, Matematicas= 9.0f, Espanol = 8.5f, Quimica = 8.0f, Fisica = 7.5f },
            new Alumno() { Id = 7, Nombre = "Gerardo Gaona" , Edad = 8, Matematicas= 6.5f, Espanol = 9f, Quimica = 9.0f, Fisica = 9.0f },
            new Alumno() { Id = 8, Nombre = "Hugo Herrera" , Edad = 11, Matematicas= 8f, Espanol = 9f, Quimica = 8.0f, Fisica = 6.0f },
            new Alumno() { Id = 9, Nombre = "Isaac Ibarrra" , Edad = 9, Matematicas= 6.5f, Espanol = 8.5f, Quimica = 8f, Fisica = 6.0f },
            new Alumno() { Id = 10, Nombre = "Julia Jurado" , Edad = 8, Matematicas= 9.0f, Espanol = 9f, Quimica = 9.0f, Fisica = 6.0f },
            };


            for (var i = 0; i < alumnos.Length; i++)
            {
                alumnos[i].Promedio = (alumnos[i].Matematicas + alumnos[i].Espanol + alumnos[i].Quimica + alumnos[i].Fisica) / 4;
                Console.WriteLine(alumnos[i].Nombre + ": " + alumnos[i].Promedio);
            }

            Console.WriteLine();
            Console.WriteLine();

            float*[] punteros = new float*[10];
            for (var i = 0; i < alumnos.Length; i++)
            {
                var promedio = alumnos[i].Promedio;
                punteros[i] = &promedio;
                Console.WriteLine((int)punteros[i]);
            }

            Console.ReadLine();
        }

        struct Alumno
        {
            public int Id;
            public string Nombre;
            public int Edad;
            public float Matematicas;
            public float Espanol;
            public float Quimica;
            public float Fisica;
            public float Promedio;
        }
    }
}
