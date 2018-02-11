using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pas de strategy :( !");

            bool isHttps = false;

            Client c = new Client();
            
            if (isHttps)
                c.ProcessHttpsRequest();
            else
                c.ProcessHttpRequest();
        }
    }
}

class Client 
{


    public void ProcessHttpsRequest()
    {
        Console.WriteLine("TraitementSecurisé...");
    }

    public void ProcessHttpRequest()
    {
        Console.WriteLine("Traitement pas Securisé...");
    }
}
