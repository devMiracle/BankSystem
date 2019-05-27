using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bankObj = new Bank();
            string NumberCard = bankObj.GenerationNumberCard();
            Console.WriteLine(NumberCard);
            Console.ReadKey();
            Console.WriteLine();
            string password = bankObj.GenerationPassword();
            Console.WriteLine(password);
            Console.ReadKey();
            Console.WriteLine();
        }
    }
}
