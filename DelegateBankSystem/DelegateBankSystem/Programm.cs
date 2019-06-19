using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem
{
    class Programm
    {
        
        public static void Main(string[] args)
        {
            Console.Title = "BANK Terminal";
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            Bank.GetFromFile(Account.filePath);
            

            //account.RegistrationNewClient();

            //account.ShowInfo();

            //account.Authorization(Bank.ListClient[0].CardNumber, Bank.ListClient[0].Password);
            GraphicInterface graphic = new GraphicInterface();
            graphic.GeneralMenu();

        }
       
    }
}
