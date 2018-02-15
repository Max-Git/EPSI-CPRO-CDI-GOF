using System;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Strategy :) !");

            bool isHttps = true;

            Client c = new Client();
            
            if (isHttps)
                c.ProcessClientRequest(new ProcessHttpsRequest());
            else
                c.ProcessClientRequest(new ProcessHttpRequest());
        }
    }
}
public interface IProcess{

    void Process();
}
class ProcessHttpRequest: IProcess{
    
    public void Process(){
        Console.WriteLine("Traitement pas Securisé...");
        
    }
}
class ProcessHttpsRequest:IProcess{

    public void Process(){
        Console.WriteLine("Traitement Securisé...");
        
    }
}
class Client 
{

    public void ProcessClientRequest(IProcess iprocess)
    {
        iprocess.Process();
    }
}
