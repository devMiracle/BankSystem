using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBankSystem
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
        public void AddMoney(Client _client, double _money)
        {
            _client.ClientMoney += _money;
        }
        public void SubtractionMoney(Client _client, double _money)
        {
            if (true)//TODO: check money != 0
            {
                _client.ClientMoney -= _money;
            }
        }
        public bool checkPasswordToAuthorization(string _password)
        {

            return false;
        }
    }
}
