using System;
using System.Collections;

namespace Lab7
{
    ////////////////////////////////////////////////////////////////////////////////
    public class Vegetables : IEnumerable
    {
        protected int size;
        protected Vegetable[] container;
        private Random rnd = new Random();

        public Vegetable[] Container { get => container; }

        /// <summary>
        /// Конструктор за замовчанням.
        /// Створює масив з 10 овочів
        /// </summary>
        public Vegetables()
        {
            size = 10;
            container = new Vegetable[size];
            FillContainer();
        }
        /// <summary>
        /// Конструктор. Створює масив заданої розмірності
        /// Створює його елементи, використовуючи рандомізацію.
        /// </summary>
        /// <param name="size">розмірність масиву</param>
        public Vegetables(int size)
        {
            this.size = size;
            container = new Vegetable[size];
            FillContainer();
        }
        /// <summary>
        /// Конструктор, якому передається масив овочів
        /// </summary>
        /// <param name="container"> масив Vegetable</param>
        public Vegetables(Vegetable[] container)
        {
            this.container = container;
            size = container.Length;
        }
        /// <summary>
        /// Заповнення масиву Vegetable
        /// </summary>
        void FillContainer()
        {
            for (int i = 0; i < size; i++)
            {
                int num = rnd.Next(3 * size);
                int price = rnd.Next(10, 200);
                int energyValue = rnd.Next(1, 150);
                int number = rnd.Next(0, 200);
                container[i] = new Vegetable("" + (1 + i), "Овоч_" + num, price.ToString(), energyValue.ToString(), number.ToString());
            }
        }
        public IEnumerator GetEnumerator()
        {
            return container.GetEnumerator();
        }
        public void Add(Vegetable m)
        {
            if (size >= 10) return;
            container[size] = m;
            ++size;
        }
    }

}