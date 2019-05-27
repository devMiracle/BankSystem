﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBankSystem
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
        private readonly List<Client> ListClient = new List<Client>();
        public void WriteToFileInfo()
        {
            //TODO: write info to file
        }
        public void GetFromFile()
        {
            //TODO: take info from file
        }
        public string GenerationNumberCard()
        {
            Random rand = new Random();
            string NumberCard = null;
            int sizeNumber = rand.Next(8, 17);
            for (int i = 0; i < sizeNumber; i++)
                NumberCard += rand.Next(0, 10).ToString();
            return NumberCard;
        }
        public string GenerationPassword()
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
