﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

class RangedUnit: Unit
    {
        public RangedUnit(int x,int y, int f)
        {
            xpos = x;
            ypos = y;
            fact = f;
            atkrange = 2;
            attk = 6;
            sp = 2;
            hp = 4;
            maxHp = 4;
            if (f == 1)
            {
                sym = "A";
            }
            else if (f == 2)
            {
                sym = "R";
            }
        }
        public override Unit[] Move(Unit[] unit, int location)
        {
            if ((Math.Abs(xpos - unit[location].Xpos) != 0) && (Math.Abs(ypos - unit[location].Ypos) != 0))
            {
                Debug.Log("not on top");
                if ((Math.Abs(xpos - unit[location].Xpos)) > (Math.Abs(ypos - unit[location].Ypos)))
                {
                Debug.Log("xpos is smaller");
                    if (xpos - unit[location].Xpos < 0)
                    {
                        xpos++;
                        Debug.Log("move in x right");
                    }
                    else if (xpos - unit[location].Xpos > 0)
                    {
                        xpos--;
                        Debug.Log("move in x left");
                    }
                }
                else if ((Math.Abs(xpos - unit[location].Xpos)) < (Math.Abs(ypos - unit[location].Ypos)))
                {
                    Debug.Log("ypos is smol");
                    Debug.Log(ypos);
                    Debug.Log(unit[location].Ypos);
                    if (ypos - unit[location].Ypos < 0)
                    {
                        ypos++;
                        Debug.Log("move in y down");
                    }
                    else if (ypos - unit[location].Ypos > 0)
                    {
                        ypos--;
                        Debug.Log("move in y up");
                    }
                }
                else if ((Math.Abs(xpos - unit[location].Xpos)) == (Math.Abs(ypos - unit[location].Ypos)))
                {
                    Debug.Log("x and y is sem, random between x and y pls");
                    System.Random r = new System.Random();
                    if (r.Next(1, 3) == 1)
                    {
                        if (ypos - unit[location].Ypos < 0)
                        {
                            ypos++;
                            Debug.Log("move in y down");
                        }
                        else if (ypos - unit[location].Ypos > 0)
                        {
                            ypos--;
                            Debug.Log("move in y up");
                        }
                    }
                    else
                    {
                        if (xpos - unit[location].Xpos < 0)
                        {
                            xpos++;
                            Debug.Log("move in x right");
                        }
                        else if (xpos - unit[location].Xpos > 0)
                        {
                            xpos--;
                            Debug.Log("move in x left");
                        }
                    }
                }
            }
            else if (xpos - unit[location].Xpos == 0)
            {
                Debug.Log("x is 0 move in y");
                if (ypos - unit[location].Ypos < 0)
                {
                    ypos++;
                    Debug.Log("move in y down");
                }
                else if (ypos - unit[location].Ypos > 0)
                {
                    ypos--;
                    Debug.Log("move in y up");
                }
            }
            else if (ypos - unit[location].Ypos == 0)
            {
                Debug.Log("y is 0 move in x");
                if (xpos - unit[location].Xpos < 0)
                {
                    xpos++;
                    Debug.Log("move in x right");
                }
                else if (xpos - unit[location].Xpos > 0)
                {
                    xpos--;
                    Debug.Log("move in x left");
                }
            }
            return unit;
        }

        public override void Run()
        {
        System.Random r = new System.Random();
            bool comp = false;
                while (!comp)
            {
                int number = r.Next(1, 4);
                switch (number)
                {
                    case 1:
                        if (xpos - 1 >= 0)
                        {
                            xpos--;
                            comp = true;
                        }
                        break;
                    case 2:
                        if (xpos + 1 <= 20)
                        {
                            xpos--;
                            comp = true;
                        }
                        break;
                    case 3:
                        if (ypos - 1 >= 0)
                        {
                            ypos--;
                            comp = true;
                        }
                        break;
                    case 4:
                        if (ypos + 1 <= 20)
                        {
                            ypos++;
                            comp = true;
                        }
                        break;
                    default:
                        break;
                }
            }

        }
        public override Unit[] Battle(Unit[] unit, int location)
        {
            unit[location].Hp = unit[location].Hp - attk;
            if (unit[location].Hp <= 0)
            {
                unit[location] = null;
            }
            return unit;
        }
        public override bool WithinRange(Unit[] unit, int location)
        {
            bool inrange = false;
            if (Math.Abs(unit[location].Xpos - xpos) > atkrange || Math.Abs(unit[location].Ypos - ypos) > atkrange)
            {
                inrange = false;
            }
            else if (Math.Abs(unit[location].Xpos - xpos) < atkrange || Math.Abs(unit[location].Ypos - ypos) < atkrange)
            {
                inrange = true;
            }

            return inrange;
        }
        public override int ClosestUnit(Unit[] unit)
        {
            int close = 0;
            int distance = 100;
            for (int i = 0; i < 12; i++)
            {
                if (unit[i] != null)
                {
                    if (fact != unit[i].Fact)
                    {
                        if (Math.Abs(unit[i].Xpos - xpos) + Math.Abs(unit[i].Ypos - ypos) < distance)
                        {
                            distance = Math.Abs(unit[i].Xpos - xpos) + Math.Abs(unit[i].Ypos - ypos);
                            close = i;
                        }

                    }
                }
            }
            return close;
        }
        public override string ToString()
        {
            return "Ranged Unit\nFaction: "+fact+"\nSymbol: "+sym+"\nX position: " + xpos+"\nY position: "+ypos+"\nMax Hp: "+maxHp+"\nCurrent Hp: "+hp+"\nRange: "+atkrange+"\nDamage: "+attk;
        }

        public override void save()
        {
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
                Debug.Log("Directory created");
            }
            else
            {
                if (!File.Exists("saves/ranged.game"))
                {
                    File.Create("saves/ranged.game");
                }
                else
                {
                    Debug.Log("There is a file");
                }

            }
            FileStream saveFile = new FileStream("saves/ranged.game", FileMode.Open, FileAccess.ReadWrite);
            StreamWriter writer = new StreamWriter(saveFile);
            StreamReader reader = new StreamReader(saveFile);
            while (reader.ReadLine() != null)
            {

            }

            writer.WriteLine(Xpos + "," + Ypos + "," + Fact + "," + Sym);
            
            writer.Close();
            saveFile.Close();
        }

        public override void read()
        {
            string line = null;
            string read = "lololol";
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
                Debug.Log("Directory created");
            }
            else
            {
                if (!File.Exists("saves/ranged.game"))
                {
                    File.Create("saves/ranged.game");
                }
                else
                {
                    Debug.Log("");
                }

            }
            FileStream saveFile = new FileStream("saves/ranged.game", FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(saveFile);
            StreamWriter writer = new StreamWriter(saveFile);
            if (saveFile.Length > 0)
            {
                read = reader.ReadLine();
                if (read != null)
                {
                    string[] parts = read.Split(',');
                    Debug.Log("reading " + parts[0]);
                    Xpos = Convert.ToInt32(parts[0]);
                    Ypos = Convert.ToInt32(parts[1]);
                    Fact = Convert.ToInt32(parts[2]);
                    Sym = parts[3];
                    writer.WriteLine(line);
                }

            }
            writer.Close();
            saveFile.Close();


        }

        ~RangedUnit()
        {

        }
    }

