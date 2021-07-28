using System;
using System.Threading.Tasks;

namespace Demo.File.Producteur
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {

                Console.WriteLine("Combien de messages voulez vous envoyer ? ");

                try
                {
                    var nombreMessages = int.Parse(Console.ReadLine());

                    var tacheEnvoi = Envoyer(nombreMessages);

                    Task.WaitAny(tacheEnvoi);
                }
                catch
                {

                }


            }

        }

        public async static Task Envoyer(int nombreMessages)
        {
            Console.WriteLine("Envoi de " + nombreMessages + " au broker ...");

            var producteur = new Producteur();

            var messages = producteur.GenererMessages(nombreMessages);

            await producteur.ProduireAsync(messages);

        }
    }
}
