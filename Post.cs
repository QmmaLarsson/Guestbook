using System;
using System.Text.Json;

namespace GuestbookConsoleApp
{
    public static class PostProgram
    {
        private const string fileName = "AllPosts.json";

        //Metod för att skapa ett nytt inlägg i gästboken
        public static void CreatePost()
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

            //Spara som som JSON-string
            string jsonString = JsonSerializer.Serialize(newPost);
            File.WriteAllText(fileName, jsonString);

            //Rensa konsollen innan nya meddelandet skapas
            Console.Clear();
            Console.WriteLine("Nytt inlägg skapat: ");
            Console.WriteLine(newPost);
        }

        //Klass som representerar ett inlägg i gästboken med en författare och ett meddelande
        public class Post(string author, string message)
        {
            public string Author { get; } = author;
            public string Message { get; } = message;

            //Returnerar en sträng med formatet "Författare - Meddelande"
            public override string ToString()
            {
                return $"{Author} - {Message}";
            }
        }
    }
}