using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBankSystem
{
    /*
    Client:
    +номер карты
    +пароль
    +сумма на счету
    */
    class Client
    {
        public string CardNumber { get; set; }
        public string Password { get; set; }
        public double ClientMoney { get; set; }

    }
}
