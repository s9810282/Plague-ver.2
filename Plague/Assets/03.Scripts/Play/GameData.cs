using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new GameData", menuName = "Game Data", order = 1)]
public class GameData : ScriptableObject
{
    [SerializeField] int infection_Level = 0;
    [SerializeField] int energy = 10;

    [SerializeField] int days = 0;

    public int Infection_Level { get => infection_Level; set => infection_Level = value; }
    public int Energy { get => energy; set => energy = value; }
    public int Days { get => days; set => days = value; }

    public void CheckEnding()
    {
        
    }
}
