using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    /*
    Client:
    +номер карты
    +пароль
    +сумма на счету
    */
    class Client
    {
        
        public string CardNumber { get; private set; }
        public string Password { get; set; }
        public double ClientMoney { get; set; }
        public Client(string numberCard, string password, double money = 0)
        {
            CardNumber = numberCard;
            Password = password;
            ClientMoney = money;
        }
    }
}
