﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Examples
{
    public class DelegateCallbackExample
    {
        public delegate void Sender(int i);
        public Sender? sender = null;
        public void RunningFunc() 
        {
            for (int i = 0; i < 10000; i++) 
            {
                Thread.Sleep(5000);
                sender(i: i); //callback
            }
        }
    }
}
