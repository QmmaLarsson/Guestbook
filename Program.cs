using System;

namespace GuestbookConsoleApp
{
    public class Program
    {
        //Metod som körs när programmet startar
        public static void Main()
        {
            //Instans av PostProgram-klassen
            PostProgram postprogram = new();
            //Laddar in alla meddelanden
            postprogram.LoadPost();

            while (true)
            {
                //Konsollen rensas innan den skrivs om
                Console.Clear();
                Console.WriteLine("EMMAS GÄSTBOK");
                Console.WriteLine("");
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");
                Console.WriteLine("");
                postprogram.PrintPost();

                //Läser in användarens val
                //Trim() tar bort eventuella mellanslag runt användarens inmatning
                //ToUpper() Säkerställer att både "X" och "x" är giltiga val
                string choice = Console.ReadLine().Trim().ToUpper();

                //Konsollen rensas innan resultatet visas
                Console.Clear();
                //Switch-sats som hanterar användarens val
                switch (choice)
                {
                    case "1":
                        //Skapa ett inlägg
                        postprogram.CreatePost();
                        break;

                    case "2":
                        postprogram.DeletePost();
                        break;

                    case "X":
                        return;

                    default:
                        Console.WriteLine("Error: Ogiltigt val");
                        break;

                }
                //Vänta med att rensa konsollen
                Console.WriteLine("Tryck på en tanget för att fortsätta.");
                Console.ReadKey();
            }
        }
    }
}