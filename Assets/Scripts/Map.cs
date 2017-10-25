using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;


class Map
    {
        string[,] map = new string[20, 20];

        public Map()
        {

        }

        public void NewMap(Unit[] unit)
        {
           
            for(int i=0;i<20;i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    map[i, k] = "^";
                }
            }

            for(int i =0; i<12;i++)
            {
                map[unit[i].Xpos, unit[i].Ypos] = unit[i].Sym;
            }

        }

        public void moveUnit()
        {

        }
        public void UpdatePosition(Unit[] unit)
        {
            
            for (int i = 0; i < 20; i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    map[i, k] = "^";
                }
            }
            map[0, 0] = "$";
            map[19, 0] = "$";
            map[19, 19] = "U";
            map[0, 19] = "U";
            for (int i = 0; i < 12; i++)
            {
                if (unit[i] != null)
                {
                    map[unit[i].Xpos, unit[i].Ypos] = unit[i].Sym;
                }

            }
        }
        public string getMap()
        {
            string output = "";
            for(int i = 0;i<20;i++)
            {
                for (int k = 0; k < 20; k++)
                {
                    output = output + map[i, k];
                }
                output = output + "\n";
            }
            return output;
        }
    }

