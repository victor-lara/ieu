using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actividad2
{
    class Program
    {
        private int Asientos { get; set; } = 3;
        private List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public int UltimoClienteCreado { get; set; } = 0;

        //Agregamos esta variable para definir en cuantos segundos llegara el nuevo cliente, es para hacerlo de forma aleatoria.
        private int TiempoSiguienteCliente { get; set; } = 2;

        //Define cuantos clientes vamos a simular en total
        private int ClientesASimular { get; set; } = 10;

        //Tiempo maximo que sera utilizado por cada cliente
        private int TiempoMaximoCliente { get; set; } = 5;

        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando programa");
            new Program().Iniciar();
        }

        public void Iniciar()
        {
            Task.Factory.StartNew(CrearClientes);
            Task.Factory.StartNew(TrabajaBarbero);

            
            Console.ReadKey();
        }

        public async void CrearClientes()
        {
            while (UltimoClienteCreado < ClientesASimular)
            {
                System.Threading.Thread.Sleep(TiempoSiguienteCliente * 1000);
                TiempoSiguienteCliente = new Random().Next(1, TiempoMaximoCliente);

                if (Clientes.Count <= Asientos - 1)
                {
                    lock (Clientes)
                    {
                        UltimoClienteCreado++;
                        Console.WriteLine($"LLego el cliente {UltimoClienteCreado}");
                        Clientes.Add(new Cliente()
                        {
                            Duracion = new Random().Next(3, TiempoMaximoCliente),
                            Id = UltimoClienteCreado
                        });
                    }
                }
                else
                {
                    Console.WriteLine("Un cliente fue rechazado");
                }
            }
        }

        public async void TrabajaBarbero()
        {
            while (UltimoClienteCreado < ClientesASimular || Clientes.Any())
            {
                if (Clientes.Any())
                {
                    Cliente cliente;
                    lock (Clientes)
                    {
                        cliente = Clientes.First();
                        Clientes.Remove(cliente);
                    }

                    Console.WriteLine($"Cliente {cliente.Id} iniciado");
                    System.Threading.Thread.Sleep(cliente.Duracion * 1000);
                    Console.WriteLine($"Cliente {cliente.Id} finalizado");
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }

            Console.WriteLine();
            Environment.Exit(0);
        }
    }


    public struct Cliente
    {
        public int Id { get; set; }
        public int Duracion { get; set; }
    }
}
