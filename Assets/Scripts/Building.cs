using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
abstract class Building
    {
        protected int xpos;
        protected int ypos;
        protected int hp;
        protected int fact;
        protected string symbol;
        public int Xpos
        {
            get
            {
                return xpos;
            }
            set
            {
                xpos = value;
            }
        }
        public int Ypos
        {
            get
            {
                return ypos;
            }
            set
            {
                ypos = value;
            }
        }
        public int Hp
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }
        public int Fact
        {
            get
            {
                return fact;
            }
            set
            {
                fact = value;
            }
        }
        public string Sym
        {
            get
            {
                return symbol;
            }
            set
            {
                symbol = value;
            }
        }

        public Building()
            {
            
            }
        public abstract void save();
        public abstract void read();

        ~Building()
        {

        }
    }

