using System;
using System.Collections.Generic;

namespace Lab7
{
    public class Vegetable : IComparable
    {
        public string id;
        public string name;
        public string price;
        public string energyValue;
        public string number;

        public Vegetable(string id, string name, string price, string energyValue, string number)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.energyValue = energyValue;
            this.number = number;
        }
        public static void ShowTable(Vegetable[] arr = null, bool showTableHeader = true)
        {
            string[] TableHeader = { "ID", "Назва", "Ціна", "Калорійність", "Кількість ящиків" };
            int idLeng = TableHeader[0].Length,
                nameLeng = TableHeader[1].Length,
                priceLeng = TableHeader[2].Length,
                energyValueLeng = TableHeader[3].Length,
                numberLeng = TableHeader[4].Length;

            foreach (var item in arr)
            {
                if (item.id.Length > idLeng)
                {
                    idLeng = item.id.Length;
                }
                if (item.name.Length > nameLeng)
                {
                    nameLeng = item.name.Length;
                }
                if (item.price.Length > priceLeng)
                {
                    priceLeng = item.price.Length;
                }
                if (item.energyValue.Length > energyValueLeng)
                {
                    energyValueLeng = item.energyValue.Length;
                }
                if (item.number.Length > numberLeng)
                {
                    numberLeng = item.number.Length;
                }
            }
            string FS_id = string.Format("| {{0, -{0}}} | ", idLeng);
            string FS_name = string.Format("{{0, -{0}}} | ", nameLeng);
            string FS_price = string.Format("{{0, -{0}}} | ", priceLeng);
            string FS_energyValue = string.Format("{{0, -{0}}} | ", energyValueLeng);
            string FS_number = string.Format("{{0, -{0}}} |", numberLeng);

            int maxLeng = idLeng + nameLeng + priceLeng + energyValueLeng + numberLeng + 16;

            string rowBorder = "\n";
            for (int i = 0; i < maxLeng; i++)
            {
                rowBorder += "=";
            }

            Console.WriteLine(rowBorder);
            if (showTableHeader)
            {
                Console.Write(FS_id, TableHeader[0]);
                Console.Write(FS_name, TableHeader[1]);
                Console.Write(FS_price, TableHeader[2]);
                Console.Write(FS_energyValue, TableHeader[3]);
                Console.Write(FS_number, TableHeader[4]);
                Console.WriteLine(rowBorder);
            }

            foreach (var s in arr)
            {
                Console.Write(FS_id, s.id);
                Console.Write(FS_name, s.name);
                Console.Write(FS_price, s.price);
                Console.Write(FS_energyValue, s.energyValue);
                Console.Write(FS_number, s.number);
                Console.WriteLine(rowBorder);
            }
        }

        public int CompareTo(object vegetable)
        {
            const string s = "Порівнюваний об'єкт не належить до класу Vegetable";
            Vegetable v = vegetable as Vegetable;
            if (!v.Equals(null))
                return int.Parse(price).CompareTo(int.Parse(v.price));
            throw new ArgumentException(s);
        }

        public static bool operator <(Vegetable v1, Vegetable v2)
        {
            return (v1.CompareTo(v2) < 0);
        }
        public static bool operator >(Vegetable v1, Vegetable v2)
        {
            return (v1.CompareTo(v2) > 0);
        }
        public static bool operator <=(Vegetable v1, Vegetable v2)
        {
            return (v1.CompareTo(v2) <= 0);
        }
        public static bool operator >=(Vegetable v1, Vegetable v2)
        {
            return (v1.CompareTo(v2) >= 0);
        }

        ////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// Сортування за ціною
        /// </summary>
        public class SortByPrice : IComparer<object>
        {
            public int Compare(object ob1, object ob2)
            {
                Vegetable v1 = (Vegetable)ob1;
                Vegetable v2 = (Vegetable)ob2;
                if (int.Parse(v1.price) > int.Parse(v2.price)) return 1;
                if (int.Parse(v1.price) < int.Parse(v2.price)) return -1;
                return 0;
            }
        }
        public class SortByNumber : IComparer<object>
        {
            /// <summary>
            /// Cортування за кількістю ящиків на складі
            /// </summary>
            /// <param name="ob1"></param>
            /// <param name="ob2"></param>
            /// <returns></returns>
            public int Compare(object ob1, object ob2)
            {
                Vegetable v1 = (Vegetable)ob1;
                Vegetable v2 = (Vegetable)ob2;
                if (int.Parse(v1.number) > int.Parse(v2.number)) return 1;
                if (int.Parse(v1.number) < int.Parse(v2.number)) return -1;
                return 0;
            }
        }

        public class SortByPriceNumber : IComparer<object>
        {
            /// <summary>
            /// Cортування за ціною і кількістю ящиків на складі
            /// </summary>
            /// <param name="ob1"></param>
            /// <param name="ob2"></param>
            /// <returns></returns>
            public int Compare(object ob1, object ob2)
            {
                int x = new SortByPrice().Compare(ob1, ob2);
                if (x != 0)
                {
                    return x;
                }
                return new SortByNumber().Compare(ob1, ob2);
            }
        }

        public class SortByID : IComparer<object>
        {
            /// <summary>
            /// Cортування за ID
            /// </summary>
            /// <param name="ob1"></param>
            /// <param name="ob2"></param>
            /// <returns></returns>
            public int Compare(object ob1, object ob2)
            {
                Vegetable v1 = (Vegetable)ob1;
                Vegetable v2 = (Vegetable)ob2;
                if (int.Parse(v1.id) > int.Parse(v2.id)) return 1;
                if (int.Parse(v1.id) < int.Parse(v2.id)) return -1;
                return 0;
            }
        }
    }

}