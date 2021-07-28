using System;
using System.Threading.Tasks;

namespace Demo.PubSub.Consommateur
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var nomSouscription = args[0];

            var souscripteur = new Souscripteur();

            await souscripteur.RecevoirMessagesAsync();

            await souscripteur.ArreterReceptionMessages();

            Console.ReadLine();
        }
    }
}
