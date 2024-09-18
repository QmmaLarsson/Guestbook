using System;
using System.Text.Json;

namespace GuestbookConsoleApp
{
    public class PostProgram
    {
        //Lista där alla gästboksinlägg sparas
        private List<Post> posts = [];
        //JSON-filen där alla gästboksinlägg sparas
        private const string fileName = "AllPosts.json";

        //Metod för att skapa ett nytt inlägg i gästboken
        public void CreatePost()
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

            //Skapa nytt inlägg med hjälp av Post-klassen och lägg till detta i posts-listan
            posts.Add(new Post(author, message));

            SavePost();

            //Rensa konsollen och meddela att nytt inlägg skapats
            Console.Clear();
            Console.WriteLine("Nytt inlägg skapat!");
        }

        //Metod som sparar inlägg i JSON-format i en separat fil
        public void SavePost()
        {
            //Spara som som JSON-string
            string jsonString = JsonSerializer.Serialize(posts);
            File.WriteAllText(fileName, jsonString);
        }

        //Metod som hämtar information från JSON-filen och konverterar den till strings i en lista
        public void LoadPost()
        {
            string jsonString = File.ReadAllText(fileName);
            posts = JsonSerializer.Deserialize<List<Post>>(jsonString) ?? [];
        }

        //Metod som läser in inlägg
        public void PrintPost()
        {
            //If-sats som kontrollerar om det finns några inlägg i gästboken
            if (posts.Count > 0)
            {
                //Om inlägg finns skrivs dessa ut till konsollen
                for (int i = 0; i < posts.Count; i++)
                {
                        Console.WriteLine($"{i}. {posts[i]}");
                }
            }
            else
            {
                //Om det inte finns några inlägg visas meddelandet "Gästboken är tom
                Console.WriteLine("Gästboken är tom.");
            }
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