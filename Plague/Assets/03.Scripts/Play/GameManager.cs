using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = new GameManager();

            return instance;
        }
    }

    private int infection_Level = 0;
    private int energy = 10;

    public int Infection_Level { get { return infection_Level; } set { infection_Level = value; } }
    public int Energy { get { return energy; } set { energy = value; } }
}
