using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

class ResourceBuilding : Building
    {
        private string type;
        private int perTick;
        private int remain;

        public ResourceBuilding(int x, int y, int fact)
        {
            xpos = x;
            ypos = y;
            remain = 1000;
            perTick = 10;
            Fact = fact;
            type = "wool";
            hp = 100;
            Sym = "$";
        }

        public int generator()
        {
            remain = remain - perTick;
            return perTick;
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
                if (!File.Exists("saves/resource.game"))
                {
                    File.Create("saves/resource.game");
                }
                else
                {
                    Debug.Log("There is a file");
                }

            }
            FileStream saveFile = new FileStream("saves/resource.game", FileMode.Open, FileAccess.ReadWrite);
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
                if (!File.Exists("saves/resource.game"))
                {
                    File.Create("saves/resource.game");
                }
                else
                {
                    Debug.Log("");
                }

            }
            FileStream saveFile = new FileStream("saves/resource.game", FileMode.Open, FileAccess.ReadWrite);
            StreamReader reader = new StreamReader(saveFile);
            StreamWriter writer = new StreamWriter(saveFile);
            if (saveFile.Length > 0)
            {
                if (reader.ReadLine() != null)
                {
                    read = reader.ReadLine();
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
