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
            int closest = 0;
            for (int i = 0; i < 12; i++)
            {
                if (unit[i] != null)
                {
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
                                unit = unit[i].Battle(unit, closest);
                            }
                        }
                        else
                        {
                            unit = unit[i].Move(unit, closest);
                        }

                    }

                }
            }
        return unit;
            
        }
    }


