using System;

namespace ListasEnlazadas
{
    public class Nodo
    {
        public int Valor;
        public Nodo? Siguiente;

        public Nodo(int valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }

    public class ListaEnlazada
    {
        private Nodo? cabeza;

        // Agregar un nodo al final
        public void Agregar(int valor)
        {
            if (cabeza == null)
            {
                cabeza = new Nodo(valor);
            }
            else
            {
                Nodo actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = new Nodo(valor);
            }
        }

        // Mostrar la lista completa
        public void Mostrar()
        {
            Nodo? actual = cabeza;
            while (actual != null)
            {
                Console.Write(actual.Valor + " -> ");
                actual = actual.Siguiente;
            }
            Console.WriteLine("null");
        }

        // EJERCICIO 3: Implementar el método de búsqueda en la lista enlazada
        // Este método busca un valor en la lista y cuenta cuántas veces aparece.
        public int Buscar(int valor)
        {
            int contador = 0;
            Nodo? actual = cabeza;
            while (actual != null)
            {
                if (actual.Valor == valor)
                    contador++;
                actual = actual.Siguiente;
            }
            return contador;
        }

        // EJERCICIO 4: Crear una lista enlazada con 50 números aleatorios
        // y eliminar los nodos cuyos valores estén fuera de un rango ingresado por el usuario.
        public void EliminarFueraDeRango(int min, int max)
        {
            while (cabeza != null && (cabeza.Valor < min || cabeza.Valor > max))
            {
                cabeza = cabeza.Siguiente;
            }

            Nodo? actual = cabeza;
            while (actual?.Siguiente != null)
            {
                if (actual.Siguiente.Valor < min || actual.Siguiente.Valor > max)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                }
                else
                {
                    actual = actual.Siguiente;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ListaEnlazada lista = new ListaEnlazada();

            // EJERCICIO 4: Generar lista con 50 números aleatorios entre 1 y 999
            Random random = new Random();
            for (int i = 0; i < 50; i++)
            {
                lista.Agregar(random.Next(1, 1000));
            }

            Console.WriteLine("Lista generada:");
            lista.Mostrar();

            // Eliminar nodos fuera de rango
            Console.WriteLine("Introduce el valor mínimo del rango:");
            int min = int.Parse(Console.ReadLine() ?? "0");
            Console.WriteLine("Introduce el valor máximo del rango:");
            int max = int.Parse(Console.ReadLine() ?? "0");
            lista.EliminarFueraDeRango(min, max);

            Console.WriteLine($"Lista después de eliminar elementos fuera del rango [{min}, {max}]:");
            lista.Mostrar();

            // EJERCICIO 3: Búsqueda de un valor en la lista enlazada
            Console.WriteLine("Introduce un valor a buscar en la lista:");
            int valor = int.Parse(Console.ReadLine() ?? "0");
            int ocurrencias = lista.Buscar(valor);
            if (ocurrencias > 0)
            {
                Console.WriteLine($"El valor {valor} aparece {ocurrencias} veces en la lista.");
            }
            else
            {
                Console.WriteLine($"El valor {valor} no se encuentra en la lista.");
            }
        }
    }
}
