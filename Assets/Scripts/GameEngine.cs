using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

class GameEngine
    {
        Map map = new Map();
        public GameEngine()
        {

        }

        public Unit[] Game(Unit[] unit)
        {
        Debug.Log("GameEngine Load");
            int closest = 0;
            for (int i = 0; i < 12; i++)
            {
                if (unit[i] != null)
                {
                Debug.Log("unit "+i+" not null");
                closest = unit[i].ClosestUnit(unit);
                    if (unit[closest] != null)
                    {
                        if (unit[i].WithinRange(unit, closest))
                        {
                            if (unit[i].Hp < unit[i].MaxHp / 4)
                            {
                                unit[i].Run();
                            }
                            else
                            {
                            Debug.Log("unit " + i + " fighting");
                            unit = unit[i].Battle(unit, closest);
                            }
                        }
                        else
                        {
                            unit = unit[i].Move(unit, closest);
                        Debug.Log("unit " + i + " fighting");
                    }

                    }

                }
            }
                return unit;
            
        }
    }


