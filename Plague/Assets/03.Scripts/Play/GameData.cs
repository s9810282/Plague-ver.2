using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new GameData", menuName = "Game Data", order = 1)]
public class GameData : ScriptableObject
{
    [SerializeField] int infection_Level = 0;
    [SerializeField] int maxInfection_Level = 10;

    [Space(10f)]

    [SerializeField] int energy = 10;
    [SerializeField] int maxEnergy = 10;

    [Space(10f)]

    [SerializeField] int days = 1;
    [SerializeField] int limitDay = 10;

    public int Infection_Level { get => infection_Level; set => infection_Level = value; }
    public int MaxInfection_Level { get => maxInfection_Level; set => maxInfection_Level = value; }
    public int Energy { get => energy; set => energy = value; }
    public int MaxEnergy { get => maxEnergy; set => maxEnergy = value; }
    public int Days { get => days; set => days = value; }
    public int LimitDay { get => limitDay; set => limitDay = value; }


    public Ending CheckEnding()
    {
        if(Days > 10)
        {
            return Ending.Clear;
        }
        else if(infection_Level >= 10)
        {
            return Ending.Infection;
        }
        else if (energy <= 0)
        {
            return Ending.Energy;
        }

        return Ending.None;
    }

    public void NomalizedData()
    {
        if (infection_Level < 0)
            infection_Level = 0;

        if (infection_Level > 0)
            infection_Level = maxInfection_Level;

        if (energy < 0)
            energy = 0;

        if (energy > 0)
            energy = MaxEnergy;
    }

    public void Reset()
    {
        infection_Level = 0;
        energy = 10;
        days = 1;
    }
}
