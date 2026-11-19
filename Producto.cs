using System;

namespace TecnoPunto
{
    // Clase que representa un producto del inventario de TecnoPunto
    public class Producto
    {
        // Campos privados: aquí se guardan los datos de verdad,
        // desde afuera solo se puede entrar por las propiedades
        private string _codigo;
        private string _nombre;
        private decimal _precio;
        private int _cantidad;

        // Código del producto (tampoco lo dejo vacío para que no haya productos sin identificar)
        public string Codigo
        {
            get { return _codigo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El código no puede estar vacío.");
                }
                _codigo = value.Trim();
            }
        }

        // El nombre no puede venir vacío ni solo con espacios
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("El nombre no puede estar vacío.");
                }
                _nombre = value.Trim();
            }
        }

        // El precio tiene que ser mayor que 0
        public decimal Precio
        {
            get { return _precio; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("El precio debe ser mayor que 0.");
                }
                _precio = value;
            }
        }

        // La cantidad puede ser 0, pero nunca negativa
        public int Cantidad
        {
            get { return _cantidad; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("La cantidad no puede ser negativa.");
                }
                _cantidad = value;
            }
        }

        // Propiedad de solo lectura (no tiene set): se calcula sola con precio x cantidad
        public decimal ValorTotal
        {
            get { return Precio * Cantidad; }
        }

        // Constructor: uso las propiedades (no los campos) para que
        // las validaciones también se hagan al crear el objeto
        public Producto(string codigo, string nombre, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }

        // Imprime la información del producto en la consola
        public void MostrarInfo()
        {
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("Código:       " + Codigo);
            Console.WriteLine("Nombre:       " + Nombre);
            Console.WriteLine("Precio:       " + Precio.ToString("N2"));
            Console.WriteLine("Cantidad:     " + Cantidad);
            Console.WriteLine("Valor total:  " + ValorTotal.ToString("N2"));
            Console.WriteLine("-----------------------------------");
        }
    }
}
