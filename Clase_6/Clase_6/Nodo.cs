using System;

namespace Clase_6
{
    // Clase Nodo para implementar la estructura enlazada
    public class Nodo
    {
        public int Dato { get; set; }
        public Nodo Siguiente { get; set; }

        public Nodo(int dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
}