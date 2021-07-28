using System;
using System.Threading.Tasks;

namespace Demo.PubSub.Producteur
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;


            while (i < 10)
            {
                i = i + 1;

                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Combien de messages voulez vous envoyer ? ");

                try
                {
                    var nombreMessages = 3;
                    ;

                    var tacheEnvoi = Publier(nombreMessages);

                    Task.WaitAny(tacheEnvoi);
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString ());
                    Environment.Exit(99); 
                }


            }

        }

        public async static Task Publier(int nombreMessages)
        {
            Console.WriteLine("Envoi de " + nombreMessages + " au broker ...");

            var producteur = new Publicateur();

            var messages = producteur.GenererMessages(nombreMessages);

            await producteur.PublierAsync(messages);

        }
    }
}
