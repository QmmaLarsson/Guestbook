using System;

namespace GuestbookConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                //Konsollen rensas innan den skrivs om
                Console.Clear();
                Console.WriteLine("EMMAS GÄSTBOK");
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg");
                Console.WriteLine("X. Avsluta");

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
                        CreatePost();
                        break;

                    case "2":
                        Console.WriteLine("Du har valt alternativ 2!");
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
        //Metod för att skapa ett nytt inlägg
        private static void CreatePost()
        {
            Console.Write("Ange ditt namn: ");
            string author = Console.ReadLine().Trim();

            Console.Write("Skriv ditt meddelande: ");
            string message = Console.ReadLine().Trim();

            //If-sats som kontrollerar om namn och meddalande är korrekt ifyllt
            if (string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(message))
            {
                Console.WriteLine("Error: Namn och/eller meddelande får inte vara tomt");
                return;
            }

            //Skapa nytt inlägg med hjälp av Post-klassen
            Post newPost = new(author, message);

            //Rensa konsollen innan nya meddelandet skapas
            Console.Clear();
            Console.WriteLine("Nytt inlägg skapat: ");
            Console.WriteLine(newPost);
        }
    }
}