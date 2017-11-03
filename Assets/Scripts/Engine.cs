using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Engine : MonoBehaviour {
    Unit[] unit = new Unit[12];
    GameEngine g = new GameEngine();
    Map map = new Map();
    Building[] build = new Building[4];
    int time = 0;
    int resource1 = 0;
    int resource2 = 0;
    int count = 0;
    int frames = 0;

    // Use this for initialization
    void Start() {
        int x = 0;
        int y = 0;
        time = 0;
        System.Random r = new System.Random();

        for (int i = 0; i < 12; i++)
        {
            for (int k = 0; k < i; k++)
            {
                x = r.Next(0, 20);
                y = r.Next(0, 20);
                if (unit[k].Xpos == x && unit[k].Ypos == y)
                {
                    k = 0;
                }
            }
            if (r.Next(1, 3) == 1)
            {
                if (i < 6)
                {
                    unit[i] = new RangedUnit(x, y, 1);
                }
                else
                {
                    unit[i] = new RangedUnit(x, y, 2);
                }
            }
            else
            {
                if (i < 6)
                {
                    unit[i] = new MeleeUnit(x, y, 1);
                }
                else
                {
                    unit[i] = new MeleeUnit(x, y, 2);
                }
            }
        }
        build[0] = new FactoryBuilding(0, 19, 1);
        build[1] = new FactoryBuilding(19, 0, 2);
        build[2] = new ResourceBuilding(0, 0, 1);
        build[3] = new ResourceBuilding(19, 19, 2);
        map.NewMap(unit);
        for (int i = 0; i < 20; i++)
        {
            for (int k = 0; k < 20; k++)
            {
                Instantiate(Resources.Load("Grass"), new Vector3(i, k, 1), Quaternion.identity);
            }
        }
        for (int i = 0; i < 12; i++)
        {
            if (unit[i].Atkrange > 1)
            {
                Instantiate(Resources.Load("Archer" + unit[i].Fact), new Vector3(unit[i].Xpos, unit[i].Ypos, -2), Quaternion.identity);
            }
            else
            {
                Instantiate(Resources.Load("Knight" + unit[i].Fact), new Vector3(unit[i].Xpos, unit[i].Ypos, -2), Quaternion.identity);
            }

        }
        Instantiate(Resources.Load("Resource" + build[3].Fact), new Vector3(build[3].Xpos, build[3].Ypos, -1), Quaternion.identity);
        Instantiate(Resources.Load("Resource" + build[2].Fact), new Vector3(build[2].Xpos, build[2].Ypos, -1), Quaternion.identity);
        Instantiate(Resources.Load("Factory" + build[1].Fact), new Vector3(build[1].Xpos, build[1].Ypos, -1), Quaternion.identity);
        Instantiate(Resources.Load("Factory" + build[0].Fact), new Vector3(build[0].Xpos, build[0].Ypos, -1), Quaternion.identity);
        //lblGameArea.Text = map.getMap()
    }
	
	// Update is called once per frame
	void Update () {
        frames++;
        if(frames%60 ==0)
        {
            Tick();
            redraw();
        }
    }

    void Tick()
    {
        unit = g.Game(unit, build);
        build = g.getbuild();
        map.UpdatePosition(unit);
        // lblGameArea.Text = map.getMap();
        time++;
        // lblTime.Text = "" + time;
        //lblAlive.Text = "Units Alive: " + count;
        if (time % 5 == 0)
        {
            if (build[1]!= null)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (unit[i] == null)
                    {
                        unit[i] = build[1].spawner();
                        i = 50;
                    }
                }
            }
            if (build[0]!= null)
            {
                for (int i = 0; i < 12; i++)
                {
                    if (unit[i] == null)
                    {
                        unit[i] = build[0].spawner();
                        i = 50;
                    }
                }
            }
        }
        //resource1 = resource1 + build[2].generator();
        //resource2 = resource2 + build[3].generator();

    }

    void redraw()
    {
        GameObject[] tagged = GameObject.FindGameObjectsWithTag("Redraw");
        foreach (GameObject x in tagged)
        {
            Destroy(x.gameObject);
        }
        for (int i = 0; i < 12; i++)
        {
            if (unit[i] != null)
            {
                if (unit[i].Atkrange > 1)
                {
                    Instantiate(Resources.Load("Archer" + unit[i].Fact), new Vector3(unit[i].Xpos, unit[i].Ypos, -2), Quaternion.identity);
                }
                else
                {
                    Instantiate(Resources.Load("Knight" + unit[i].Fact), new Vector3(unit[i].Xpos, unit[i].Ypos, -2), Quaternion.identity);
                }
            }
        }
        for(int i=0;i<4;i++ )
        {
            if(build[i] != null)
            {
                if (build[i].MaxHp == 150)
                {
                    Instantiate(Resources.Load("Resource" + build[i].Fact), new Vector3(build[i].Xpos, build[i].Ypos, -1), Quaternion.identity);
                }
                else
                {
                    Instantiate(Resources.Load("Factory" + build[i].Fact), new Vector3(build[i].Xpos, build[i].Ypos, -1), Quaternion.identity);
                }
            }
        }

    }

    }
    
