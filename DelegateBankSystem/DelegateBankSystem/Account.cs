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
        public static string filePath = "data.txt";
        public delegate void MyDel(string filePath, string text);
        public event MyDel EventRegistration;
        Client clientAuthorizationTarget;
        public bool Authorization(string cardNumber, string password)
        {
            foreach (var item in Bank.ListClient)
            {
                if (item.CardNumber == cardNumber && item.Password == password)
                {
                    //TODO: Event вызывающий ЛК и + все, что в этом теле(подумать: может не стоит вызывать ЛК от сюда.)
                    clientAuthorizationTarget = item;
                    Console.WriteLine("Авторизация успешна");
                    Console.ReadKey();
                    return true;
                }
                else
                {
                    Console.WriteLine("Пользователь не найден");
                    Console.ReadKey();

                    return false;
                }

            }
            return false;
        }
        public string RegistrationNewClient()
        {
            string cardNum = Bank.GenerationNumberCard();
            string pass = Bank.GenerationPassword();
            Bank.ListClient.Add(new Client(cardNum, pass));
            EventRegistration?.Invoke(filePath, cardNum + ":" + pass);
            return cardNum + ":" + pass;
        }
        
        public void DepositMoney(double _money)
        {
            
        }
        public void WithdrawMoney(double _money)
        {
            if (true)//TODO: check money != 0
            {

            }
        }
        
    }
}
