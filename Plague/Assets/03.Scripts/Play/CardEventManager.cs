using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    /// <summary>
    /// ¤¸°°´Ù
    /// </summary>
    /// 

    [SerializeField] FieldCardManager fieldCardManager;

    [SerializeField] HandCardManager handCardManager;

    [SerializeField] GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        FiedlEventSetting();

        fieldCardManager.GameStart();
        handCardManager.GameStart();
    }

    public void FiedlEventSetting()
    {
        handCardManager.EventSetting(fieldCardManager.SetFieldLeft, fieldCardManager.SetFieldRight);
    }


    public void CardSettingEnd()
    {
        ClosingFieldCard();
        gameData.CheckEnding();
    }

    public void ClosingFieldCard()
    {
        FieldCard[] fieldCard = fieldCardManager.ReturnSituationCards();
        FieldBehaviourCard[] behaviourCards = fieldCardManager.ReturnFieldBehaviourCards();


    }

    public void SituationCardProcess(SituationCard situationCard)
    {
        //Gain
        int rand = Random.Range(0, 100);

        if (rand < situationCard.gain.Infection_Lever_Per)
            gameData.Infection_Level += situationCard.gain.Infection_Level_Variation;

        rand = Random.Range(0, 100);

        if (rand < situationCard.gain.Energy_Change_Per)
            gameData.Energy += situationCard.gain.Energy_Change_Volume;


        rand = Random.Range(0, 100);

        if (situationCard.gain.GetFood && rand < situationCard.gain.FoodPer)
            handCardManager.AddCard(0);
        else if (situationCard.gain.GetMedician && rand < situationCard.gain.MedicionPer)
            handCardManager.AddCard(1);

        //Pain
        rand = Random.Range(0, 100);

        if (rand < situationCard.pain.Infection_Lever_Per)
            gameData.Infection_Level -= situationCard.pain.Infection_Level_Variation;

        rand = Random.Range(0, 100);

        if (rand < situationCard.pain.Energy_Change_Per)
            gameData.Energy -= situationCard.pain.Energy_Change_Volume;


        handCardManager.CardDisPotal(situationCard.pain.CardDispotal);
    }

    public void BehaviourCardProcess(BehaviorCard behaviorCard)
    {
        
    }
}

