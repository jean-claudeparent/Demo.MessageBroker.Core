using System;
using System.Threading.Tasks;
using System.Threading;



namespace Demo.PubSub.Producteur
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 0;


            while (i < 1)
            {
                i = i + 1;

                

                try
                {
                    var nombreMessages = 3;
                    ;

                    var tacheEnvoi = Publier(nombreMessages);

                    Task.WaitAny(tacheEnvoi);
                    Thread.Sleep (10000);
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
