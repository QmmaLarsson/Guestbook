﻿using System;

namespace GuestbookConsoleApp
{
    public class Program
    {
        //Metod som körs när programmet startar
        public static void Main()
        {   
            PostProgram postprogram = new();
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
                        postprogram.CreatePost();
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
    }
}