﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TiendaEnLinea2.Data.Repository
{
    public class ReferenciaPago
    {
        public string GenRef (string userid, ApplicationDbContext context)
        {
            var user = context.Users.Find(userid);
            string Ref = user.NormalizedUserName + Set();
            return Ref;
        }
        private protected char Let()
        {
            string str = "abcdefghijklmnaopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return str[new Random().Next(0, str.Length - 1)];
        }
        private protected int Len()
        {
            return new Random().Next(5, 22);
        }
        private protected int Num()
        {
            return new Random().Next(0, 10);
        }
        private protected string Set()
        {
            string data = "";
            int len = Len();
            for (int i = 0; i < len; i++)
            {
                int x = new Random().Next(0, 2);
                if (x == 0)
                {
                    data += Let();
                }
                else
                {
                    data += Num().ToString();
                }
            }
            return data;
        }
    }
}
