using System;
using System.Collections.Generic;
using System.Linq;

namespace Serie1AdmonEquipos
{
    /*
     * Declaración de las estructuras
     */
    public struct Device
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public double DeviceCost { get; set; }
        public double LoanCost { get; set; }
        public CustomDate DeliveryDate { get; set; }
    }
    public struct CustomDate
    {
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public override string ToString() => $"{Day}/{Month}/{Year}";
    }

    class Program
    {
        static List<Device> Devices = new List<Device>();
        static void Main(string[] args)
        {
            ConsoleKeyInfo opt;
            do
            {
                ShowMenu();
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        AddDevice();
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        ProcessDevice();
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        ListDevices();
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Console.WriteLine("VUELVA PRONTO!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("ESTA OPCIÓN NO EXISTE, INTENTE DE NUEVO!!");
                        Console.ReadKey();
                        break;

                }
            } while (!opt.Key.Equals(ConsoleKey.Escape));
        }
        static void ShowMenu()
        {
            //menu
            CenterText("ADMINISTRACIÓN EQUIPOS DE CÓMPUTO");
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("Curso: PROGRAMACIÓN I");
            Console.WriteLine("Nombre: Luis Eduardo Alvarado Celano");
            Console.WriteLine("Carnet: 0900-20-7376");
            Console.WriteLine("Sección: C");
            Console.WriteLine("\n");
            CenterText("-------------------------------------");
            CenterText("MENÚ PRINCIPAL");
            CenterText("-------------------------------------");
            CenterLeftText("(1). REGISTRAR EQUIPO");
            CenterLeftText("(2). PROCESAR EQUIPO");
            CenterLeftText("(3). VER LISTADO DE EQUIPOS EN PRÉSTAMO");
            CenterLeftText("(Esc). SALIR DEL SISTEMA");
            CenterText("-------------------------------------");
            CenterText("ELIJA EL NÚMERO DE OPCIÓN [ ]");
            CenterText("-------------------------------------");

        }
        static void AddDevice()
        {
            Console.Clear();
            CenterText("AGREGAR EQUIPO");
            Device device = new Device();
            CustomDate date = new CustomDate();
            try
            {
                Console.SetCursorPosition(20, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 8); Console.WriteLine("DATOS GENERALES");
                Console.SetCursorPosition(20, 9); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 10); Console.WriteLine("DESCRIPCIÓN EQUIPO:       [____________________________________________]");
                Console.SetCursorPosition(52, 10);
                device.Desc = Console.ReadLine();
                Console.SetCursorPosition(20, 11); Console.WriteLine("COSTO DEL EQUIPO:   [____________________________________________]");
                Console.SetCursorPosition(52, 11);
                device.DeviceCost = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(20, 12); Console.WriteLine("COSTO DEL PRESTAMO:   [____________________________________________]");
                Console.SetCursorPosition(52, 12);
                device.LoanCost = double.Parse(Console.ReadLine());
                Console.SetCursorPosition(20, 13); Console.WriteLine("FECHA DE ENTREGA");
                Console.SetCursorPosition(20, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 15); Console.WriteLine("DÍA:   [____________________________________________]");
                Console.SetCursorPosition(52, 15);
                date.Day= int.Parse(Console.ReadLine());
                Console.SetCursorPosition(20, 16); Console.WriteLine("MES:   [____________________________________________]");
                Console.SetCursorPosition(52, 16);
                date.Month = int.Parse(Console.ReadLine());
                Console.SetCursorPosition(20, 17); Console.WriteLine("AÑO:   [____________________________________________]");
                Console.SetCursorPosition(52, 17);
                date.Year = int.Parse(Console.ReadLine());
                device.DeliveryDate = date;
                if (Devices.Count == 0) { device.Id = 1; }
                else { device.Id = Devices[Devices.Count - 1].Id + 1; }
                Devices.Add(device);
                Console.SetCursorPosition(20, 18); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 19); Console.WriteLine("EQUIPO REGISTRADO CORRECTAMENTE");
                Console.SetCursorPosition(20, 20); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();

            }
            catch(Exception e)
            {
                Console.SetCursorPosition(20, 18); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 19); Console.WriteLine("ERROR AL REGISTRAR EL EQUIPO: {0}", e.Message);
                Console.SetCursorPosition(20, 20); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void ProcessDevice()
        {
            Console.Clear();
            CenterText("PROCESAR EQUIPO");
            try 
            { 
                Console.SetCursorPosition(20, 7); Console.WriteLine("INGRESA EL IDENTIFICADOR DEL EQUIPO:       [____________________________________________]");
                Console.SetCursorPosition(72, 7);
                int result = int.Parse(Console.ReadLine());
                Device deviceFound = Devices.Find(device => device.Id == result);
                Console.SetCursorPosition(20, 9); Console.WriteLine("ESTÁS SEGURO QUE DESEAS ELIMINAR EL EQUIPO? (S/N)");
                Console.SetCursorPosition(72, 9);
                ConsoleKeyInfo opt;
                opt = Console.ReadKey();
                switch (opt.Key)
                {
                    case ConsoleKey.S:
                        Devices.Remove(deviceFound);
                        Console.SetCursorPosition(20, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                        Console.SetCursorPosition(20, 11); Console.WriteLine("EQUIPO ELIMINADO CORRECTAMENTE");
                        Console.SetCursorPosition(20, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.SetCursorPosition(20, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                        Console.SetCursorPosition(20, 11); Console.WriteLine("OPERACIÓN CANCELADA");
                        Console.SetCursorPosition(20, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(20, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(20, 11); Console.WriteLine("ERROR AL ELIMINAR EL EQUIPO: {0}",e.Message);
                Console.SetCursorPosition(20, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void ListDevices()
        {
            Console.Clear();
            CenterText("EQUIPOS DE CÓMPUTO EN PRÉSTAMO");
            int curr = 9;
            try
            {
                if (Devices.Count == 0) throw new Exception("NO HAY EQUIPOS DE CÓMPUTO REGISTRADOS");
                Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 6); Console.WriteLine("ID EQUIPO");
                Console.SetCursorPosition(20, 6); Console.WriteLine("DESCRIPCIÓN");
                Console.SetCursorPosition(60, 6); Console.WriteLine("COSTO EQUIPO");
                Console.SetCursorPosition(80, 6); Console.WriteLine("COSTO PRÉSTAMO");
                Console.SetCursorPosition(100, 6); Console.WriteLine("FECHA DE ENTREGA");
                Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 8);
                foreach(Device device in Devices)
                {
                    Console.SetCursorPosition(5, curr); Console.WriteLine(device.Id);
                    Console.SetCursorPosition(20, curr); Console.WriteLine(device.Desc);
                    Console.SetCursorPosition(60, curr); Console.WriteLine(device.DeviceCost.ToString("C2"));
                    Console.SetCursorPosition(80, curr); Console.WriteLine(device.LoanCost.ToString("C2"));
                    Console.SetCursorPosition(100, curr); Console.WriteLine(device.DeliveryDate.ToString());
                    curr++;
                }
                Console.SetCursorPosition(5, curr); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
            catch(Exception e)
            {
                Console.SetCursorPosition(5, curr); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, curr+1); Console.WriteLine(e.Message);
                Console.SetCursorPosition(5, curr+2); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void CenterLeftText(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + text.Length - 15) + "}", text));
        }
        static void CenterText(string text)
        {
            Console.WriteLine(string.Format("{0," + ((Console.WindowWidth / 2) + (text.Length / 2)) + "}", text));
        }
    }
}
