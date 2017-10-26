using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;


    class FactoryBuilding : Building
    {
     
            private int spawnx;
        private int spawny;
            private int ticks;
            private int type;
        public int Ticks
        {
            get
            {
                return ticks;
            }
            set
            {
                ticks = value;
            }
        }

        public FactoryBuilding(int x, int y, int fact)
            {
            xpos = x;
            ypos = y;
            spawnx = x;
            spawny = y;
            ticks = 5;
            Fact = fact;
        maxHp = 150;
        hp = 100;
            Sym = "U";
            hp = 100;
            }
    public override int generator()
    {
        throw new NotImplementedException();
    }
    public override Unit spawner()
            {
            System.Random rand = new System.Random();
            type = rand.Next(1, 3);
                Unit unit;
                if (type == 1)
                {
                    unit = new MeleeUnit(spawnx, spawny, Fact);
                }
                else
                {
                    unit = new RangedUnit(spawnx, spawny, Fact);
                }
                return unit;
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
                if (!File.Exists("saves/factory.game"))
                {
                    File.Create("saves/factory.game");
                }
                else
                {
                    Debug.Log("There is a file");
                }

            }
            FileStream saveFile = new FileStream("saves/factory.game", FileMode.Open, FileAccess.ReadWrite);
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
            string read = "";
            if (!Directory.Exists("saves"))
            {
                Directory.CreateDirectory("saves");
                Debug.Log("Directory created");
            }
            else
            {
                if (!File.Exists("saves/factory.game"))
                {
                    File.Create("saves/factory.game");
                }
                else
                {
                    Debug.Log("");
                }

            }
            FileStream saveFile = new FileStream("saves/factory.game", FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(saveFile);
            StreamWriter writer = new StreamWriter(saveFile);
            if (saveFile.Length > 0)
            {
                read = reader.ReadLine();
                if (read != null)
                {
                    
                    string[] parts = read.Split(',');
                    Xpos = Convert.ToInt32(parts[0]);
                    Ypos = Convert.ToInt32(parts[1]);
                    Fact = Convert.ToInt32(parts[2]);
                    writer.WriteLine(line);
                }
            }
            writer.Close();
            saveFile.Close();
        }

    }
