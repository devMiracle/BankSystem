using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankSystem
{
    /*
    Banc:
    +содержит список клиентов
    метод для записи данных в файл
    метод для считывания данных из файла
    +метод для генерирования данных о карте
    +метод для генерирования пароля
    */
    class Bank
    {
        public static List<Client> ListClient = new List<Client>();
        public static void WriteToFileInfo(string filePath, string text)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Unicode))
                {
                    foreach (var item in ListClient)
                    {
                        sw.WriteLine(item.CardNumber + ':' + item.Password + ':' + item.ClientMoney);
                    }
                    
                }

            }
            
        }
        public static void GetFromFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Unicode))
                {
                    while (!sr.EndOfStream)
                    {
                        string cardNumAndPassString = sr.ReadLine();
                        string[] cardNumAndPassMassive = cardNumAndPassString.Split(new char[] { ':' });
                        string CardNum = cardNumAndPassMassive[0];
                        string pass = cardNumAndPassMassive[1];
                        string moneyStr = cardNumAndPassMassive[2];
                        double money = double.Parse(moneyStr);
                        ListClient.Add(new Client(CardNum, pass, money)); 
                    }
                }

            }
        }
        public static string GenerationNumberCard()
        {
            Random rand = new Random();
            string NumberCard = null;
            int sizeNumber = rand.Next(8, 17);
            for (int i = 0; i < sizeNumber; i++)
                NumberCard += rand.Next(0, 10).ToString();
            return NumberCard;
        }
        public static string GenerationPassword()
        {
            Random rand = new Random();
            string password = null;
            int sizePassword = rand.Next(8, 17);
            for (int i = 0; i < sizePassword; i++)
            {
                switch (rand.Next(0, 3))
                {
                    case 0:
                        password += (char)rand.Next(65, 91);
                        break;
                    case 1:
                        password += (char)rand.Next(97, 123);
                        break;
                    case 2:
                        password += rand.Next(0, 10).ToString();
                        break;
                }
            }
            return password;
        }
    }
}
