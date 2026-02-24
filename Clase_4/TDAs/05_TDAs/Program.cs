
using EjListaEnlazadaSimple;
using EjListaEnlazadaDoble;
using EjListaCircular;
using EjListaDobleCircular;


ListaEnlzadaSimple lista = new ListaEnlzadaSimple();
lista.append(new Nodo(new Pelicula("El Padrino", "Francis Ford Coppola", 1972)));
lista.append(new Nodo(new Pelicula("El Padrino II", "Francis Ford Coppola", 1974)));
lista.append(new Nodo(new Pelicula("El Padrino III", "Francis Ford Coppola", 1990)));
lista.print();
lista.pop();
Console.WriteLine("Después de eliminar el último nodo:");
lista.print();
lista.append(new Nodo(new Pelicula("El Padrino IV", "Francis Ford Coppola", 2020)));
Console.WriteLine("Después de agregar el último nodo:");
lista.print();

Console.WriteLine("\n\nLista Enlazada Doble:");
ListaEnlazadaDoble listaDoble = new ListaEnlazadaDoble();
listaDoble.append(new NodoLED(new EjListaEnlazadaDoble.Libro("Cien Años de Soledad", "Gabriel García Márquez", 1967)));
listaDoble.append(new NodoLED(new EjListaEnlazadaDoble.Libro("Don Quijote de la Mancha", "Miguel de Cervantes", 1605)));
listaDoble.append(new NodoLED(new EjListaEnlazadaDoble.Libro("La Sombra del Viento", "Carlos Ruiz Zafón", 2001)));
Console.WriteLine("Lista en orden ascendente:"); 
listaDoble.printAcendente();
Console.WriteLine("Lista en orden descendente:");
listaDoble.printDescendente();
listaDoble.pop();
Console.WriteLine("Después de eliminar el último nodo:");
listaDoble.printAcendente();
listaDoble.append(new NodoLED(new EjListaEnlazadaDoble.Libro("El Amor en los Tiempos del Cólera", "Gabriel García Márquez", 1985)));
Console.WriteLine("Después de agregar el último nodo:");
listaDoble.printAcendente();
listaDoble.reset();
Console.WriteLine("Después de resetear la lista:");
listaDoble.printAcendente();



