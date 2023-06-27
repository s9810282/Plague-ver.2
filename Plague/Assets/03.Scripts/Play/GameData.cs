using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new GameData", menuName = "Game Data", order = 1)]
public class GameData : ScriptableObject
{
    [SerializeField] int infection_Level = 0;
    [SerializeField] int energy = 10;

    [SerializeField] int days = 0;


    public void CheckEnding()
    {
        
    }
}
