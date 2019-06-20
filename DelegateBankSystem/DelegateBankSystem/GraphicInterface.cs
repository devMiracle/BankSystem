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
        static string[] MenuAccountParts = { "пополнить", "снять", "выход" };
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
                            account.clientAuthorizationTarget = null;
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
            Console.Write(" Пароль:");
            string password = Console.ReadLine();
            if (account.Authorization(numberOfCard, password))
            {
                MenuAccount();
            }
            
            
        }
        private void MenuRegistration()
        {
            account.EventRegistration += BankDataBase.WriteToFileInfo;
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
            bool backRollOneStep = true;
            int targetMenu = 1;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, 0);
                foreach (var item in border)
                {
                    Console.WriteLine(item);
                }
                Console.SetCursorPosition(2, 1);
                Console.Write("\tЛичный кабинет");
                Console.SetCursorPosition(2, 2);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"   № карты: {account.clientAuthorizationTarget.CardNumber}");
                Console.ResetColor();
                Console.SetCursorPosition(2, 3);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"   Баланс: {account.clientAuthorizationTarget.ClientMoney}");
                Console.ResetColor();
                for (int i = 0; i < MenuAccountParts.Length; i++)
                {
                    if (targetMenu - 1 == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    Console.SetCursorPosition(x, y + 2 + i);
                    Console.Write(MenuAccountParts[i]);
                    Console.ResetColor();
                }
                key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.Enter:
                        if (targetMenu == 1)
                        {
                            MenuDeposit();
                        }
                        if (targetMenu == 2)
                        {
                            MenuWithdraw();
                        }
                        if (targetMenu == 3)
                        {
                            backRollOneStep = false;
                        }
                        break;
                    case ConsoleKey.Escape:
                        backRollOneStep = false;
                        break;
                    case ConsoleKey.UpArrow:
                        if (targetMenu == 1)
                        {
                            break;
                        }
                        targetMenu--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (targetMenu == 3)
                        {
                            break;
                        }
                        targetMenu++;
                        break;
                    default:
                        break;
                }


            } while (backRollOneStep);
        }
        private void MenuDeposit()
        {
            account.EventDeposit += BankDataBase.WriteToFileInfo;
            Console.Clear();
            foreach (var item in border)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(2, 2);
            Console.Write("введите сумму: ");
            Console.SetCursorPosition(2, 3);
            string moneyStr = Console.ReadLine();
            
            if (double.TryParse(moneyStr, out double moneyDouble))
            {
                account.DepositMoney(moneyDouble);
            }
            else
            {
                Console.SetCursorPosition(2, 4);
                Console.Write("не допустимое значение");
                Console.ReadKey();
            }
            Console.Clear();
        }
        private void MenuWithdraw()
        {
            account.EventWithdraw += BankDataBase.WriteToFileInfo;
            Console.Clear();
            foreach (var item in border)
            {
                Console.WriteLine(item);
            }
            Console.SetCursorPosition(2, 2);
            Console.Write("введите сумму: ");
            Console.SetCursorPosition(2, 3);
            string moneyStr = Console.ReadLine();

            if (double.TryParse(moneyStr, out double moneyDouble))
            {
                account.WithdrawMoney(moneyDouble);
            }
            else
            {
                Console.SetCursorPosition(2, 4);
                Console.Write("не допустимое значение");
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}
