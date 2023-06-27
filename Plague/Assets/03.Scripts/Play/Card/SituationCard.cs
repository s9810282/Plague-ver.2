using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PNGain
{
    public int Infection_Level_Variation;
    public int Energy_Change_Volume;

    [Space(10f)]

    public int Infection_Lever_Per;
    public int Energy_Change_Per;

    [Space(10f)]

    public bool GetMedician;
    public bool GetFood;

    [Space(10f)]

    public int MedicionPer;
    public int FoodPer;
}

[System.Serializable]
public struct PNPain
{
    public int Infection_Level_Variation;
    public int Energy_Change_Volume;

    [Space(10f)]

    public int Infection_Lever_Per;
    public int Energy_Change_Per;

    [Space(10f)]

    public int CardDispotal;
}



[CreateAssetMenu(fileName = "new Field SituationCard CardData", menuName = "Filed SituationCard Card Data", order = 2)]
public class SituationCard : Card
{
    public PNGain gain;

    [Space(10f)]    

    public PNPain pain;

    public bool PN;

}