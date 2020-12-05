using System;
using Trena;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingProducts
{
	/// <summary>
	/// Тестовый класс
	/// </summary>
	[TestClass]
	public class Testings
	{
		/// <summary>
		/// Тестирование метода Equals при одинаковых объектах
		/// </summary>
		[TestMethod]
		public void TestingCEquals_SameObject()
		{
			Product product1 = new Food
				{ name = "Meat", price = 12.5, markup = 1.2, numerous = 40 };
			Product product2 = new Food
				{ name = "Meat", price = 12.5, markup = 1.2, numerous = 40 };

			var expected = true;
			var actual = product1.Equals(product2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование метода Equals при разных объектах
		/// </summary>
		[TestMethod]
		public void TestingCEquals_DiffObject()
		{
			Product product1 = new Food
			{ name = "Meat", price = 12.5, markup = 1.2, numerous = 40 };
			Product product2 = new Food
			{ name = "Bun", price = 2.4, markup = 1.43, numerous = 120 };

			var expected = false;
			var actual = product1.Equals(product2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование методы Equals при null
		/// </summary>
		[TestMethod]
		public void TestingCEquals_NullObject()
		{
			Product product1 = new Food
			{ name = "Meat", price = 12.5, markup = 1.2, numerous = 40 };
			Product product2 = null;

			var expected = false;
			var actual = product1.Equals(product2);

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженного оператора '+', сложение двух объектов одного вида и наименования
		/// </summary>
		[TestMethod]
		public void TestingPlusTwoSameObject()
		{
			Product product1 = new Food
				{ name = "Meat", price = 12.0, markup = 1.4, numerous = 40 };
			Product product2 = new Food
				{ name = "Meat", price = 20.0, markup = 1.2, numerous = 40 };

			var expected = new Food
			{ name = "Meat", price = 16.0, markup = 1.3, numerous = 80 };
			
			var actual = (Food)product1 + (Food)product2;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженного метода '-', для вычитания целого числа
		/// </summary>
		[TestMethod]
		public void TestingMinusNumerous()
		{
			Product product1 = new Food
			{ name = "Meat", price = 12.0, markup = 1.4, numerous = 40 };

			var expected = new Food
			{ name = "Meat", price = 12.0, markup = 1.4, numerous = 16 };

			var actual = (Food)product1 - 24;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженного метода ToString()
		/// </summary>
		[TestMethod]
		public void TestingMOverloadToString()
		{
			Product product1 = new Food
			{ name = "Meat", price = 12.0, markup = 1.4, numerous = 40 };

			var expected = "\nView = Trena.Food, Name = Meat, Price = 12, " +
				"Markup = 1,4, Numerous = 40";

			var actual = product1.ToString();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженного метода GetHashCode
		/// </summary>
		[TestMethod]
		public void TestingMOverloadGetHashCode()
		{
			Product product1 = new Food
			{ name = "Meat", price = 12.0, markup = 1.4, numerous = 40 };

			var expected = 40;
			var actual = product1.GetHashCode();

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженног метода приведения объекта к базовому типу int
		/// </summary>
		[TestMethod]
		public void TestingTransformInInt()
		{
			Product product1 = new Food
			{ name = "Meat", price = 2.34, markup = 1.4, numerous = 40 };

			var expected = 234;
			var actual = (int)product1;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тестирование перегруженного метода приведения типа к базовому типу double
		/// </summary>
		[TestMethod]
		public void TestingTransformInDoouble()
		{
			Product product1 = new Food
			{ name = "Meat", price = 2.34, markup = 1.4, numerous = 40 };

			var expected = 2.34;
			var actual = (double)product1;

			Assert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Проверка работы нескольких методов и операций сразу (используется приведение типов)
		/// </summary>
		[TestMethod]
		public void TestingMix()
		{
			Product product1 = new Food
				{ name = "Meat", price = 2.34, markup = 1.4, numerous = 22 };
			Product product2 = new Food
			{ name = "Meat", price = 21.4, markup = 1.1, numerous = 40 };

			Product p_plus = (Food)product1 + (Food)product2;
			Product pr = (Food)p_plus - 30;
			var expected = 32;

			var actual = pr.GetHashCode();
			Assert.AreEqual(expected, actual);
		}

	}
}
