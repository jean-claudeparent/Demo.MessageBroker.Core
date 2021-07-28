using System;

namespace Demo.File.Consommateur
{
    class Program
    {
        static void Main(string[] args)
        {
            var consomateur = new Consomateur();

            consomateur.RecevoirAsync();

            Console.ReadLine();
        }
    }
}
