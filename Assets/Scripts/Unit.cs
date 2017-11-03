using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;



abstract class Unit
    {
        protected int xpos;
        protected int ypos;
        protected int hp;
        protected int sp;
        protected int attk;
        protected int atkrange;
        protected int fact;
        protected string sym;
        protected int maxHp;
        protected string name;
        public int Xpos {
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
        public int Sp
        {
            get
            {
                return sp;
            }
            set
            {
                sp = value;
            }
        }
        public int Attk
        {
            get
            {
                return attk;
            }
            set
            {
                attk = value;
            }
        }
        public int Atkrange
        {
            get
            {
                return atkrange;
            }
            set
            {
                atkrange = value;
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
                return sym;
            }
            set
            {
                sym = value;
            }
        }
        public int MaxHp
        {
            get
            {
                return maxHp;
            }
            set
            {
                maxHp = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public Unit()
        {

        }
        public abstract void Run();
        public abstract Unit[] Move(Unit[] unit, int location);
        public abstract Unit[] Battle(Unit[] unit, int location);
        public abstract Building[] MoveBuild(Building[] build, int location);
        public abstract Building[] BattleBuild(Building[] build, int location);
        public abstract bool WithinRange(Unit[] unit, int location);
        public abstract bool WithinRangeBuild(Building[] build, int location);
        public abstract int ClosestUnit(Unit[] unit);
        public abstract int ClosestBuilding(Building[] build);
        public override abstract string ToString();
        public abstract void save();
        public abstract void read();
        /*public abstract void setYpos(int value);
        public abstract void setHp(int value);
        public abstract void setSpeed(int value);
        public abstract void setAttk(int value);
        public abstract void setRange(int value);
        public abstract void setFact(int value);
        public abstract void setSymbol(string value);
        public abstract int xpos;
        public abstract int yPos;
        public abstract int hp;
        public abstract int getSpeed();
        public abstract int getAttk();
        public abstract int getRange();
        public abstract int getFact();
        public abstract string getSymbol();
        public abstract int getMaxHp();*/


        ~Unit()
        {

        }
    }

