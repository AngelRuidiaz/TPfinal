
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WiW
{
	public class MaxHeap
	{
	    private List<Dato> heap;
	
	    public MaxHeap()
	    {
	        heap = new List<Dato>();
	    }
	
	    public void Agregar(Dato dato)
	    {
	        heap.Add(dato);
	        int indice = heap.Count - 1;
	        while (indice > 0)
	        {
	            int indicePadre = (indice - 1) / 2;
	            if (heap[indicePadre].ocurrencia < heap[indice].ocurrencia)
	            {
	                Dato temp = heap[indicePadre];
	                heap[indicePadre] = heap[indice];
	                heap[indice] = temp;
	                indice = indicePadre;
	            }
	            else
	            {
	                break;
	            }
	        }
	    }
	
	    public Dato ExtraerMaximo()
	    {
	        if (heap.Count == 0)
	        {
	            throw new InvalidOperationException("El montículo está vacío");
	        }
	
	        Dato maximo = heap[0];
	        heap[0] = heap[heap.Count - 1];
	        heap.RemoveAt(heap.Count - 1);
	
	        int indice = 0;
	        while (true)
	        {
	            int indiceIzquierdo = 2 * indice + 1;
	            int indiceDerecho = 2 * indice + 2;
	            int indiceMayor = indice;
	
	            if (indiceIzquierdo < heap.Count && heap[indiceIzquierdo].ocurrencia > heap[indiceMayor].ocurrencia)
	            {
	                indiceMayor = indiceIzquierdo;
	            }
	            if (indiceDerecho < heap.Count && heap[indiceDerecho].ocurrencia > heap[indiceMayor].ocurrencia)
	            {
	                indiceMayor = indiceDerecho;
	            }
	
	            if (indiceMayor != indice)
	            {
	                Dato temp = heap[indice];
	                heap[indice] = heap[indiceMayor];
	                heap[indiceMayor] = temp;
	                indice = indiceMayor;
	            }
	            else
	            {
	                break;
	            }
	        }
	
	        return maximo;
	    }
	
	    public List<Dato> ObtenerHeap()
	    {
	        return heap;
	    }
	}
}