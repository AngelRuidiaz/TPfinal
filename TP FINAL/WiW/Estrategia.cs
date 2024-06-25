
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;
using System.Text;

namespace WiW
{

	public class Estrategia
	{
		public static List<Dato> aux;

		public List<Dato> BuscarConHeap(List<string> datos, int cantidad, List<Dato> collected)
		    { 
		        Dictionary<string, int> ocurrencias = new Dictionary<string, int>();
		
		        foreach (string datoStr in datos)
		        {
		            if (ocurrencias.ContainsKey(datoStr))
		                ocurrencias[datoStr]++;
		            else
		                ocurrencias[datoStr] = 1;
		        }
		
		        MaxHeap heap = new MaxHeap();
		
		        foreach (var kvp in ocurrencias)
		        {
		            string texto = kvp.Key;
		            int ocurrencia = kvp.Value;
		            string descripcion = "";
		            heap.Agregar(new Dato(ocurrencia, texto, descripcion));
		        }
		
		        for (int i = 0; i < cantidad; i++)
		        {
		       
		            collected.Add(heap.ExtraerMaximo());
		            
		        }
		        aux=new List<Dato>(collected);
		        return collected;
		    }
		    
		
		
		    public string Consulta1(List<string> datos)
		    {
		        // Crear una lista para almacenar los resultados de la consulta
		        List<Dato> resultadoHeap = new List<Dato>();
		        List<Dato> resultadoOtro = new List<Dato>();
		
		        // Medir el tiempo de ejecución del método BuscarConHeap()
		        Stopwatch swHeap = Stopwatch.StartNew();
		        BuscarConHeap(datos, 5, resultadoHeap);
		        swHeap.Stop();
		        TimeSpan tiempoHeap = swHeap.Elapsed;
		
		        // Medir el tiempo de ejecución del método BuscarConOtro()
		        Stopwatch swOtro = Stopwatch.StartNew();
		        BuscarConOtro(datos, 5, resultadoOtro);
		        swOtro.Stop();
		        TimeSpan tiempoOtro = swOtro.Elapsed;
		
		        // Construir el texto con los tiempos de ejecución
		       string textoTiempo = "Tiempo BuscarConHeap(): " + tiempoHeap.TotalMilliseconds + " ms\n";
		       textoTiempo += "Tiempo BuscarConOtro(): " + tiempoOtro.TotalMilliseconds + " ms\n";
		
		        return textoTiempo;
		    }
		   
		    
		    public string Consulta2(List<Dato> lista)
		    {
		        if (aux.Count == 0)
		        {
		            return "La lista está vacía";
		        }
		       
		        StringBuilder camino = new StringBuilder();
		        Dato nodoActual = aux[0];
		
		        camino.Append(nodoActual.texto);
		
		        while (true)
		        {
		            int indiceActual = aux.IndexOf(nodoActual);
		            int indiceHijoIzquierdo = 2 * indiceActual + 1;
		
		            if (indiceHijoIzquierdo < aux.Count)
		            {
		                nodoActual = aux[indiceHijoIzquierdo];
		                camino.Append(" -> ").Append(nodoActual.texto);
		            }
		            else
		            {
		                break; // Alcanzamos una hoja
		            }
		        }
		
		        return camino.ToString();
		        
		        
		    }
		    
		      public string Consulta3(List<string> datos)
		      {
			    // Obtener la lista de Dato utilizando BuscarConHeap
			    List<Dato> listaDatos = aux;
			
			    StringBuilder resultado = new StringBuilder();
			
			    // Recorrer la lista de Dato para construir el texto
			    foreach (var dato in listaDatos)
			    {
			        int nivel = ObtenerNivel(dato, listaDatos);
			        resultado.AppendLine(string.Format("Dato: {0}, Nivel: {1}", dato.texto, nivel));

			    }
			    return resultado.ToString();
			}
		    
			
			private int ObtenerNivel(Dato dato, List<Dato> listaDatos)
			{
			    // Calcular el nivel del dato en la heap
			    int nivel = 1;
			    int indiceDato = listaDatos.IndexOf(dato);
			
			    while (indiceDato > 0)
			    {
			        indiceDato = (indiceDato - 1) / 2;
			        nivel++;
			    }
			    
			    return nivel;
		    	}
       

			public void BuscarConOtro(List<string> datos, int cantidad, List<Dato> collected)
			{
			    // Agrupar los datos por su ocurrencia
			    var agrupados = datos.GroupBy(dato => dato)
			                         .Select(grupo => new Dato
			                         {
			    	        		 ocurrencia = grupo.Count(),
			                             texto = grupo.Key,
			                             descripcion = ""
			                         });
			
			    // Ordenar los datos agrupados por ocurrencia de mayor a menor y luego por descripción
			    var ordenados = agrupados.OrderByDescending(dato => dato.ocurrencia)
			                             .ThenBy(dato => dato.descripcion)
			                             .Take(cantidad);
			
			    // Agregar los datos ordenados a la lista de resultados
			    foreach (var dato in ordenados)
			    {
			        collected.Add(dato);
			    }
			}
		
		

	}
}