using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class CardEventManager : MonoBehaviour
{
    /// <summary>
    /// ㅈ같다
    /// </summary>
    /// 

    [SerializeField] FieldCardManager fieldCardManager;

    [SerializeField] HandCardManager handCardManager;

    [SerializeField] GameData gameData;

    [Space(30f)]


    bool isOnlyIgnore = false;
    bool isInfectionIgnore = false;


    bool isPNNull = false;
    bool isPN = false;

    void Start()
    {
        isOnlyIgnore = false;
        isInfectionIgnore = false;

        isPNNull = false;
        isPN = true;

        gameData.Reset();

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

        isOnlyIgnore = false;
        isInfectionIgnore = false;

        isPNNull = false;
        isPN = true;

        gameData.CheckEnding();
    }

    public void ClosingFieldCard()
    {
        FieldCard[] fieldCard = fieldCardManager.ReturnSituationCards();
        FieldBehaviourCard[] behaviourCards = fieldCardManager.ReturnFieldBehaviourCards();
        
        BehaviourCardProcess(behaviourCards[0]._Card);
        BehaviourCardProcess(behaviourCards[1]._Card);

        SituationCardProcess(fieldCard[0]._Card);
        SituationCardProcess(fieldCard[1]._Card);

        gameData.NomalizedData();
        gameData.Days += 1;

        fieldCardManager.ResetField();
        handCardManager.NextDay();
    }


    public void BehaviourCardProcess(BehaviorCard behaviorCard)
    {

        if (behaviorCard.cardType == CardType.HandPN)
        {
            isPN = behaviorCard.PN;
            isPNNull = behaviorCard.cardType == CardType.HandPN;
        }

        if (behaviorCard.OnlyIgnore)
            isOnlyIgnore = true;

        if (behaviorCard.Infection_Level_Ignore)
            isInfectionIgnore = true;


        gameData.Infection_Level += behaviorCard.Infection_Level_Variation;
        gameData.Energy += behaviorCard.Energy_Change_Volume;
    }
    public void SituationCardProcess(SituationCard situationCard)
    {

        if (isOnlyIgnore)
            return;

        if (!isPN)
            return;

        if (!isPNNull && situationCard.PN)  //만약 긍정 부정 카드를 안썼다면 
        {
            int random = Random.Range(0, 100);

            if (random < 50)
                return;
        }

        Debug.Log(situationCard.cardName);

        //Gain
        int rand = Random.Range(0, 100);

        if (rand < situationCard.gain.Infection_Lever_Per)
            gameData.Infection_Level -= situationCard.gain.Infection_Level_Variation;

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

        if (rand < situationCard.pain.Infection_Lever_Per && !isInfectionIgnore)
            gameData.Infection_Level += situationCard.pain.Infection_Level_Variation;

        rand = Random.Range(0, 100);

        if (rand < situationCard.pain.Energy_Change_Per)
            gameData.Energy -= situationCard.pain.Energy_Change_Volume;


        handCardManager.CardDisPotal(situationCard.pain.CardDispotal);
    }
}

