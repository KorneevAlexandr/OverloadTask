using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trena
{
	/// <summary>
	/// Базовый класс товаров
	/// </summary>
	public class Product
	{
		/// <summary>
		/// Наименование вида продуктов
		/// </summary>
		public string name { get; set; }
		/// <summary>
		/// Закупочная цена
		/// </summary>
		public double price { get; set; }

		/// <summary>
		/// Приведение типа к int (стоимость возвращается в копейках)
		/// </summary>
		/// <param name="comp">Объект, который приводится к другому типу</param>
		public static explicit operator int(Product comp)
		{
			return (int)(comp.price * 100);
		}
		/// <summary>
		/// Приведение типа к double
		/// </summary>
		/// <param name="comp">Объект, который приводится к другому типу</param>
		public static explicit operator double(Product comp)
		{
			return comp.price;
		}

	}
}
