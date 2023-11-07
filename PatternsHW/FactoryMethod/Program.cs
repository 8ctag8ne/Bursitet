using System;
namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract BigUkrainian FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override BigUkrainian FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new Rogul();
                //повертає об'єкт B, якщо type==2  
                case 2: return new Kozhuh();
                case 3: return new Propukanyi();
                default: return new AdekVat();
            }
        }
    }

    public abstract class BigUkrainian //абстрактний клас продукт
    { 
        public abstract void ShowInfo();
    } 

    //конкретні продукти з різною реалізацією
    public class Rogul : BigUkrainian 
    {
        public override void ShowInfo()
        {
            Console.WriteLine("🤬");
        }
    }

    public class Kozhuh : BigUkrainian 
    {
        public override void ShowInfo()
        {
            Console.WriteLine("🤮");
        }
    }

    public class Propukanyi : BigUkrainian
    {
        public override void ShowInfo()
        {
            Console.WriteLine("👉🐓");
        }
    }

    public class AdekVat : BigUkrainian
    {
        public override void ShowInfo()
        {
            Console.WriteLine("✌️🎈");
        }
    }

    class MainApp
    {
        static void Main()
        {       //створюємо творця
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 5; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                Console.Write($"Vasha #prosharka = {i}; ");
                product.ShowInfo();
            }
            Console.ReadKey();
        }
    }
}

