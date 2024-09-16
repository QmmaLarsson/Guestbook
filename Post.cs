using System;

namespace GuestbookConsoleApp
{
    public class Post(string author, string message)
    {
        public string Author { get; } = author;
        public string Message { get; } = message;

        public override string ToString()
        {
            return $"{Author} - {Message}";
        }

    }
}