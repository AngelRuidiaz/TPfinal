using System;
using System.Collections.Generic;

namespace WiW
{ 
    public class Backend
    {
        public static List<string> datos = new List<string>();
        public static List<Dato> dato = new List<Dato>();

        public static string aProfundidad()
        {
            return (new Estrategia()).Consulta3(datos);
        }

        public static string caminoAPrediccion()
        {
            return (new Estrategia()).Consulta2(dato);
        }

        public static string todasLasPredicciones()
        {
            return (new Estrategia()).Consulta1(datos);
        }

        public static void buscar(bool heapOP, int cantidad, List<Dato> collected)
        {
            
            if (heapOP)
            {
                (new Estrategia()).BuscarConHeap(datos, cantidad, collected);
            }
            else
            {
                (new Estrategia()).BuscarConOtro(datos, cantidad, collected);
            }
            
        }
    }

}