using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trena
{
	/// <summary>
	/// Класс для работы с Task
	/// </summary>
	public class CreateProducts
	{
		/// <summary>
		/// Фабричный метод создания объектов
		/// </summary>
		/// <returns>Список объектов</returns>
		public List<Product> Fabric()
		{
			ParsingText pars = new ParsingText();
			var Data = pars.ReadFile();

			List<Product> AllProducts = new List<Product>();
			for (int i = 0; i < Data.Result.Name.Length; i++)
			{
				Product product = null;

				if (Data.Result.View[i] == "Food")
				{
					product = new Food
					{
						name = Data.Result.Name[i],
						price = Data.Result.PurchasePrice[i],
						markup = Data.Result.Markup[i],
						numerous = Data.Result.Numerous[i]
					};
				}
				else if (Data.Result.View[i] == "Computer")
				{
					product = new Computer
					{
						name = Data.Result.Name[i],
						price = Data.Result.PurchasePrice[i],
						markup = Data.Result.Markup[i],
						numerous = Data.Result.Numerous[i]
					};
				}
				else if (Data.Result.View[i] == "Furniture")
				{
					product = new Furniture
					{
						name = Data.Result.Name[i],
						price = Data.Result.PurchasePrice[i],
						markup = Data.Result.Markup[i],
						numerous = Data.Result.Numerous[i]
					};
				}
				else if (Data.Result.View[i] == "Clothes")
				{
					product = new Clothes
					{
						name = Data.Result.Name[i],
						price = Data.Result.PurchasePrice[i],
						markup = Data.Result.Markup[i],
						numerous = Data.Result.Numerous[i]
					};
				}

				AllProducts.Add(product);
			}

			return AllProducts;
		}

	}
}
