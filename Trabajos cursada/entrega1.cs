using System;
using System.Collections.Generic;

public class Program
{
	public class Arbol<T>
	{
	    public T Valor { get; set; }
	    public Arbol<T> Izquierdo { get; set; }
	    public Arbol<T> Derecho { get; set; }
	
	    public Arbol(T valor)
	    {
	        Valor = valor;
	        Izquierdo = null;
	        Derecho = null;
	    }
	   public List<int> Resolver(Arbol<int> arbol, int longitud)
	    {
	        var resultado = new List<int>();
	        if (EncontrarCamino(arbol, longitud, new List<int>(), resultado))
	        {
	            return resultado;
	        }
	        return new List<int>();
	    }
	
	    private bool EncontrarCamino(Arbol<int> nodo, int longitud, List<int> caminoActual, List<int> resultado)
	    {
	        if (nodo == null)
	        {
	            return false;
	        }
	
	        caminoActual.Add(nodo.Valor);
	
	        if (nodo.Izquierdo == null && nodo.Derecho == null && caminoActual.Count == longitud + 1)
	        {
	            resultado.AddRange(caminoActual);
	            return true;
	        }
	        
	        if (EncontrarCamino(nodo.Izquierdo, longitud, caminoActual, resultado) || EncontrarCamino(nodo.Derecho, longitud, caminoActual, resultado))
	        {
	            return true;
	        }
	        caminoActual.RemoveAt(caminoActual.Count - 1);
	        return false;
	    }
	}
	public static void Main()
	{
		var arbol = new Arbol<int>(8);
		arbol.Izquierdo = new Arbol<int>(5);
	       arbol.Derecho = new Arbol<int>(22);
	       arbol.Derecho.Izquierdo = new Arbol<int>(6);
	       arbol.Derecho.Derecho = new Arbol<int>(18);
	       arbol.Derecho.Izquierdo.Izquierdo = new Arbol<int>(7);

	        var resultado1 = arbol.Resolver(arbol, 1);
	        Console.WriteLine("Longitud 1: " + string.Join("-", resultado1));
	
	        var resultado2 = arbol.Resolver(arbol, 2);
	        Console.WriteLine("Longitud 2: " + string.Join("-", resultado2));
	
	        var resultado5 = arbol.Resolver(arbol, 5);
	        Console.WriteLine("Longitud 5: " + string.Join("-", resultado5));
	        Console.ReadLine();
	   }
}
