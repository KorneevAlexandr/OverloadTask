using System;
using Trena;
using System.Collections.Generic;

namespace HelloApp
{
    /// <summary>
    /// Начальный класс
    /// </summary>
    class Program
    {
        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args">Аргументы метода Main()</param>
        static void Main(string[] args)
        {
            CreateProducts create = new CreateProducts();
            /// Список с объектами типа Product для последующей работы
            List<Product> AllProduct = create.Fabric();
            Console.ReadKey();
        }
    }
}