using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class GraphicInterface
    {
        string[] border = {     "------------------------------\n",
                                "*                            *\n",
                                "*                            *\n",
                                "*                            *\n",
                                "------------------------------\n"};
        Account account = new Account();
        static int x = 2;
        static int y = 2;
        static string[] menuParts = { "Авторизация", "Регистрация", "Выход" };
        public void GeneralMenu()
        {
            int targetMenu = 1;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, 0);
                foreach (var item in border)
                {
                    Console.WriteLine(item);
                }
                for (int i = 0; i < menuParts.Length; i++)
                {
                    if (targetMenu - 1 == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(menuParts[i]);
                    Console.ResetColor();
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        if (targetMenu == 1)
                        {
                            MenuAuthorization();
                            Console.Clear();
                        }
                        if (targetMenu == 2)
                        {
                            MenuRegistration();
                            Console.Clear();
                        }
                        if (targetMenu == 3)
                        {
                            Environment.Exit(0);
                        }
                        //если меню будет расширяться, допилить еще if'ов
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.UpArrow:
                        if (targetMenu == 1)
                            break;
                        targetMenu--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (targetMenu == menuParts.Length)
                            break;
                        targetMenu++;
                        break;
                    default:
                        break;
                }
            } while (true);
        }
        private void MenuAuthorization()
        {
            Console.Clear();
            foreach (var item in border)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(x, y);
            Console.Write("№ карты:");
            string numberOfCard = Console.ReadLine();
            Console.SetCursorPosition(x, y + 1);
            Console.Write("Пароль:");
            string password = Console.ReadLine();
            if (account.Authorization(Bank.ListClient[0].CardNumber, Bank.ListClient[0].Password))
            {
                Console.WriteLine("test if()");
                Console.ReadKey();
            }
            
            
        }
        private void MenuRegistration()
        {
            account.EventRegistration += Bank.WriteToFileInfo;
            Console.Clear();
            foreach (var item in border)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(x, y);
            string cardNumAndPassString = account.RegistrationNewClient();
            string[] cardNumAndPassMassive = cardNumAndPassString.Split(new char[] { ':' });
            string CardNum = cardNumAndPassMassive[0];
            string pass = cardNumAndPassMassive[1];
            Console.Write("Регистрация выполнена.");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("Вам присвоенно:");
            Console.SetCursorPosition(x, y + 2);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"№ карты: {CardNum}");
            Console.SetCursorPosition(x, y + 3);
            Console.Write($"Пароль: {pass}");
            Console.ResetColor();
            Console.SetCursorPosition(x, y + 4);
            Console.Write("Нажмите любую клавишу");
            Console.ReadKey();
        }
        private void MenuAccount()
        {
            Console.Clear();
            


        }
    }
}
