using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test singleton");
            Singleton.GetInstance.DisplayHello();
            Singleton.GetInstance.DisplayHello();
            Singleton.GetInstance.DisplayHello();
        }
    }

    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton() { }
        
        public static Singleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    Console.WriteLine("Nouvelle instance");
                    instance = new Singleton();
                }
                else
                {
                    Console.WriteLine("Même instance");
                }

                return instance;
            }
        }

        public void DisplayHello()
        {
            Console.WriteLine("Hello");
        }
         
    }
}
