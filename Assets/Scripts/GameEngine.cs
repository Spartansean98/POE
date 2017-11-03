using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;

class GameEngine
{
    Map map = new Map();
    Building[] temp = new Building[4];
    public GameEngine()
    {

    }

    public Unit[] Game(Unit[] unit, Building[] build)
    {
        Debug.Log("GameEngine Load");
        int closestUnit = 0;
        int closestBuild = 0;
        for (int i = 0; i < 12; i++)
        {
            if (unit[i] != null)
            {
                Debug.Log("unit " + i + " not null");
                closestUnit = unit[i].ClosestUnit(unit);
                closestBuild = unit[i].ClosestBuilding(build);
                if (unit[closestUnit] != null && build[closestBuild] != null)
                {
                    if ((Math.Abs(unit[closestUnit].Xpos - unit[i].Xpos)+ Math.Abs(unit[closestUnit].Ypos - unit[i].Ypos)) > (Math.Abs(build[closestBuild].Xpos - unit[i].Xpos)+ Math.Abs(build[closestBuild].Ypos - unit[i].Ypos)))
                    {
                        if (unit[i].WithinRangeBuild(build, closestBuild))
                        {
                            build = unit[i].BattleBuild(build, closestBuild);
                        }
                        else
                        {
                            build = unit[i].MoveBuild(build, closestBuild);
                        }
                    }
                    else
                    {
                        if (unit[i].WithinRange(unit, closestUnit))
                        {
                            if (unit[i].Hp < unit[i].MaxHp / 4)
                            {
                                unit[i].Run();
                            }
                            else
                            {
                                Debug.Log("unit " + i + " fighting");
                                unit = unit[i].Battle(unit, closestUnit);
                            }
                        }
                        else
                        {
                            unit = unit[i].Move(unit, closestUnit);
                            Debug.Log("unit " + i + " fighting");
                        }

                    }

                }
            }
        }
        temp = build;
            return unit;

        
    }

    public Building[] getbuild()
    {
        return temp;
    }
}


