using System;
using System.Media;

namespace CyberSecurityChatbot
{
    public class Chatbot
    {
        public string UserName { get; set; }

        public void StartChat()
        {
            PlayVoiceGreeting();
            ShowHeader();
            AskName();
            ChatLoop();
        }
        private void PlayVoiceGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");
                SoundPlayer player = new SoundPlayer(path);
                player.PlaySync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing voice greeting: " + ex.Message);

            }
        }

        private void ShowHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"   ______      __              _____                      _ __           ___                                               
  / ____/_  __/ /_  ___  _____/ ___/___  _______  _______(_) /___  __   /   |_      ______ _________  ____  ___  __________
 / /   / / / / __ \/ _ \/ ___/\__ \/ _ \/ ___/ / / / ___/ / __/ / / /  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/
/ /___/ /_/ / /_/ /  __/ /   ___/ /  __/ /__/ /_/ / /  / / /_/ /_/ /  / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  ) 
\____/\__, /_.___/\___/_/   /____/\___/\___/\__,_/_/  /_/\__/\__, /  /_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/  
     /____/                                                 /____/                                                         ");
            Console.WriteLine("   CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("====================================");
            Console.ResetColor();
        }

        private void AskName()
        {
            Console.Write("Enter your name: ");
            UserName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(UserName))
            {
                Console.WriteLine("Name cannot be empty!");
                AskName();
            }

            Console.WriteLine($"Hello {UserName}, welcome 😊");
        }

        private void ChatLoop()
        {
            while (true)
            {
                Console.Write("\nYou: ");
                string input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: Please say something...");
                    continue;
                }

                Respond(input);
            }
        }

        private void Respond(string input)
        {
            if (input.Contains("how are you"))
            {
                Console.WriteLine("Bot: I'm good! Ready to help you stay safe online.");
            }
            else if (input.Contains("purpose"))
            {
                Console.WriteLine("Bot: My purpose is to teach cybersecurity awareness.");
            }
            else if (input.Contains("password"))
            {
                Console.WriteLine("Bot: Use strong passwords with letters, numbers, and symbols.");
            }
            else if (input.Contains("phishing"))
            {
                Console.WriteLine("Bot: Don't click suspicious links or emails.");
            }
            else if (input.Contains("safe browsing"))
            {
                Console.WriteLine("Bot: Always check website URLs before entering details.");
            }
            else
            {
                Console.WriteLine("Bot: I didn't understand that. Try asking about passwords or phishing.");
            }
        }
    }
}
