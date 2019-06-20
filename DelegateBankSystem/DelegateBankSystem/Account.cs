using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /*
    Account:
    методы для зачисления/растраты денег
    метод проверки пароля при авторизации
    метод для установки значения в поле "опасных" попыток авторизации. 
    После "правильной" авторизации значение обнуляется.
    Вывод данных по аккаунту
    метод для изменения пароля
    */
    class Account
    {
        public delegate void MyDel(string filePath);
        public event MyDel EventRegistration;

        public delegate void Mydel2(string filePath);
        public event Mydel2 EventDeposit;
        public event Mydel2 EventWithdraw;

        public Client clientAuthorizationTarget;

        public static string filePath = "data.txt";

        public bool Authorization(string cardNumber, string password)
        {
            foreach (var item in BankDataBase.ListClient)
            {
                if (item.CardNumber == cardNumber && item.Password == password)
                {
                    clientAuthorizationTarget = item;
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(2, 5);
                    Console.WriteLine("Авторизация успешна");
                    Console.ResetColor();
                    Console.ReadKey();
                    return true;
                }
            }
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(2, 5);
            Console.WriteLine("Пользователь не найден");
            Console.ResetColor();
            Console.ReadKey();
            return false;
        }
        public string RegistrationNewClient()
        {
            string cardNum = BankDataBase.GenerationNumberCard();
            string pass = BankDataBase.GenerationPassword();
            BankDataBase.ListClient.Add(new Client(cardNum, pass));
            EventRegistration?.Invoke(filePath);
            return cardNum + ":" + pass;
        }
        
        public void DepositMoney(double _money)
        {
            if (clientAuthorizationTarget != null)
            {
                clientAuthorizationTarget.ClientMoney += _money;
                EventDeposit?.Invoke(filePath);
            }

        }
        public void WithdrawMoney(double _money)
        {
            if (clientAuthorizationTarget != null)
            {
                if (clientAuthorizationTarget.ClientMoney >= _money)
                {
                    clientAuthorizationTarget.ClientMoney -= _money;
                    EventWithdraw?.Invoke(filePath);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.SetCursorPosition(2, 5);
                    Console.Write("вы хохите снять больше,");
                    Console.SetCursorPosition(2, 6);
                    Console.Write("чем есть.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
        }
        
    }
}
