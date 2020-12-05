using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace Trena
{
    /// <summary>
    /// Класс, использующийся для записи его полей в файле .json
    /// </summary>
    public class AllData
    {
        /// <summary>
        /// Вид товара
        /// </summary>
        public string[] View { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string[] Name { get; set; }
        /// <summary>
        /// Закупочная цена товара
        /// </summary>
        public double[] PurchasePrice { get; set; }
        /// <summary>
        /// Наценка на товар
        /// </summary>
        public double[] Markup { get; set; }
        /// <summary>
        /// Количество единиц товара
        /// </summary>
        public int[] Numerous { get; set; }
    }

    /// <summary>
    /// Класс для чтения и записи файла .json
    /// </summary>
    public class ParsingText
    {
       /// <summary>
       /// Метод записи в файл .json
       /// Необходимо передаваить объект типа AllData со всеми заполненными полями
       /// </summary>
       /// <param name="data">Объект класса AllData с информацией, которую необходимо записать</param>
       /// <returns>тип Task</returns>
       public async Task WriteFile(AllData data)
       {
            // сохранение данных
            using (FileStream fs = new FileStream(@"D:\Учеба\Training\TrenirovkaTask2\Trena\json1.json", 
                FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<AllData>(fs, data);
            }         
       }


        /// <summary>
        /// Метод считывания файла форматом .json
        /// </summary>
        /// <returns>Объект со всеми значениями из файла</returns>
        public async Task<AllData> ReadFile()
        {
            // чтение данных
            using (FileStream fs = new FileStream(@"D:\Учеба\Training\TrenirovkaTask2\Trena\json1.json", 
                FileMode.OpenOrCreate))
            {
				var Data = await JsonSerializer.DeserializeAsync<AllData>(fs);
                return Data;
            }

        }
    }
}
