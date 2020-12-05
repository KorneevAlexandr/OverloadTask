using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trena
{
	/// <summary>
	/// Класс для учеты видов компьютеров
	/// </summary>
	public class Computer : Product
	{
		/// <summary>
		/// Наценка на товар
		/// </summary>
		public double markup { get; set; }
		/// <summary>
		/// Количество единиц товара
		/// </summary>
		public int numerous { get; set; }

		/// <summary>
		/// Вычисление цены за единицу товара с учетом наценки
		/// </summary>
		/// <returns>Цена за единицу товара с учетом наценки</returns>
		public double PriceUnit()
		{
			return price * markup;
		}
		/// <summary>
		/// Подсчет цены за весь товар с учетом наценки
		/// </summary>
		/// <returns>Число, цена за весь товар с учетом наценки</returns>
		public double PriceFull()
		{
			return price * markup * numerous;
		}

		/// <summary>
		/// Сложение двух объектов данного класса
		/// </summary>
		/// <param name="p1">1 объект</param>
		/// <param name="p2">2 объект</param>
		/// <returns>Объект этого класса с средневзвешенной ценной и
		/// наценкой двух других объектов </returns>
		public static Product operator +(Computer p1, Computer p2)
		{
			if (p1 == null || p2 == null)
				throw new Exception("Одного из объектов не существует");
			if (p1.GetType() != p2.GetType() || p1.name != p2.name)
				throw new Exception("Разные виды или наименования");

			int all_numerous = p1.numerous + p2.numerous;
			double middle_price = (p1.numerous * p1.price + p2.numerous * p2.price) /
				all_numerous;

			double proc_markup_1, proc_markup_2;
			proc_markup_1 = 100.0 / all_numerous * p1.numerous;
			proc_markup_2 = 100.0 / all_numerous * p2.numerous;
			double middle_markup;
			middle_markup = (proc_markup_1 * p1.markup + proc_markup_2 * p2.markup) / 100.0;

			Product product = new Computer
			{
				name = p1.name,
				price = Math.Round(middle_price, 2),
				markup = Math.Round(middle_markup, 2),
				numerous = all_numerous
			};
			return product;
		}

		/// <summary>
		/// Перегруженная операция вычитания целого числа из объекта
		/// </summary>
		/// <param name="p1">Объект</param>
		/// <param name="x">Целое число</param>
		/// <returns>Объект, с уменьшенным количеством ед товара</returns>
		public static Product operator -(Computer p1, int x)
		{
			if (x > p1.numerous)
				throw new Exception("Количество единиц товара не может быть отрицательным");
			Product product = new Computer
			{
				name = p1.name,
				price = p1.price,
				markup = p1.markup,
				numerous = p1.numerous - x
			};
			return product;
		}

		/// <summary>
		/// Перегрузка метода ToString()
		/// </summary>
		/// <returns>Строка с информацией о товаре</returns>
		public override string ToString()
		{
			string str;
			str = String.Format("\nView = {0}, Name = {1}, " +
				"Price = {2}, Markup = {3}, Numerous = {4}",
				GetType(), name, price, markup, numerous);
			return str;
		}
		/// <summary>
		/// Перегрузка метода Equals() для сравнения текущего и заданного объектов
		/// </summary>
		/// <param name="obj">Заданный объект</param>
		/// <returns>true - если одинаковы, false - если разные</returns>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;
			Computer F = obj as Computer;
			if (F as Computer == null)
				return false;

			if (name != F.name || price != F.price || markup != F.markup || numerous != F.numerous)
				return false;

			return true;
		}

		/// <summary>
		/// Хеш-функция
		/// </summary>
		/// <returns>Количество единиц товара</returns>
		public override int GetHashCode()
		{
			return numerous;
		}

	}
}
