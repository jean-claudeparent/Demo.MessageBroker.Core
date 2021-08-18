using System;
using System.Threading.Tasks;
using System.Threading;



namespace Demo.PubSub.Consommateur
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var nomSouscription = args[0];

            var souscripteur = new Souscripteur();

            await souscripteur.RecevoirMessagesAsync();
            Thread.Sleep (20000);
            await souscripteur.ArreterReceptionMessages();

            // Console.ReadLine();
            
        }
    }
}
