using System;
using System.Collections.Generic;

public class Empleado
{
    public string Nombre { get; set; }
    public int Legajo { get; set; }
    public int DNI { get; set; }

    public Empleado(string nombre, int legajo, int dni)
    {
        Nombre = nombre;
        Legajo = legajo;
        DNI = dni;
    }
}

public class TablaHash
{
    private const int TamTabla = 10;
    private List<Empleado>[] tabla;

    public TablaHash()
    {
        tabla = new List<Empleado>[TamTabla];
    }

    private int HashFunction(int dni)
    {
       
        return dni % TamTabla;
    }

    public void AgregarEmpleado(Empleado empleado)
    {
        int indice = HashFunction(empleado.DNI);

        if (tabla[indice] == null)
        {
            tabla[indice] = new List<Empleado>();
        }

        tabla[indice].Add(empleado);
    }

    public Empleado ObtenerEmpleadoPorDNI(int dni)
    {
        int indice = HashFunction(dni);

        if (tabla[indice] != null)
        {
            foreach (Empleado empleado in tabla[indice])
            {
                if (empleado.DNI == dni)
                {
                    return empleado;
                }
            }
            
        }
        return null; 
    }
}

class Program
{
    static void Main(string[] args)
    {
        TablaHash tablaEmpleados = new TablaHash();

        
        Empleado empleado1 = new Empleado("Juan Buseta", 1001, 45812456);
        Empleado empleado2 = new Empleado("Candela Galdo", 1002, 21843574);
        Empleado empleado3 = new Empleado("Carlos Gerez", 1003, 45187495);

        tablaEmpleados.AgregarEmpleado(empleado1);
        tablaEmpleados.AgregarEmpleado(empleado2);
        tablaEmpleados.AgregarEmpleado(empleado3);

        
        int dniBuscado = 45187495;
        Empleado empleadoBuscado = tablaEmpleados.ObtenerEmpleadoPorDNI(dniBuscado);

        if (empleadoBuscado != null)
        {
            Console.WriteLine($"Empleado encontrado: {empleadoBuscado.Nombre} - Número de empleado: {empleadoBuscado.Legajo}");
        }
        else
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }
}
