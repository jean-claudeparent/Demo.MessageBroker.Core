using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.PubSub.Consommateur
{
    public class Souscripteur
    {
        private string _chaineConnexion = @"Endpoint=sb://rqbus1.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=YyZItf3LrFuhpvuiYb0b5R9d6xzNY4++znQvw2fIDDk=";
        private string _nomTopic = "topic1";
        private string _nomSouscription = "subscription2";

        public static ServiceBusProcessor processor;

        public Souscripteur()
        {
          
        }


        public async Task RecevoirMessagesAsync()
        {
            var client = new ServiceBusClient(_chaineConnexion);

            // create a processor that we can use to process the messages
            processor = client.CreateProcessor(_nomTopic, _nomSouscription, new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += ActionSuccesReception;

            processor.ProcessErrorAsync += ActionErreurReception;

            // Commence à écouter le topic 
            await processor.StartProcessingAsync();

            Console.WriteLine("En attente de message sur le topic {0} - souscription {1} ...", _nomTopic, _nomSouscription);

        }

        public async Task ArreterReceptionMessages()
        {
            Console.ReadKey();
            Console.WriteLine("\nArrêt du souscripteur...");
            await processor.StopProcessingAsync();
            Console.WriteLine("Le souscripteur a arreté de recevoir les messages");
        }

        static async Task ActionSuccesReception(ProcessMessageEventArgs consommateur)
        {
            string contenuMessage = consommateur.Message.Body.ToString();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Message recu : " + contenuMessage);
            Console.ForegroundColor = ConsoleColor.White;

            await consommateur.CompleteMessageAsync(consommateur.Message);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Confirmation de traitement Envoyée  : " + contenuMessage);
            Console.ForegroundColor = ConsoleColor.White;

        }

        static Task ActionErreurReception(ProcessErrorEventArgs args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Une erreur est survenue lors de la reception du message : " + args.Exception.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            return Task.CompletedTask;
        }

    }
}
