using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new BehaviorCard CardData", menuName = "BehaviorCard Card Data", order = 2)]
public class BehaviorCard : Card
{
    public int Infection_Level_Variation;
    public int Energy_Change_Volume;

    public bool Infection_Level_Ignore;
    public bool OnlyIgnore;

    public bool PN;
}
