using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    /// <summary>
    /// ������
    /// </summary>
    /// 

    [SerializeField] FieldCardManager fieldCardManager;

    [SerializeField] HandCardManager handCardManager;

    [SerializeField] GameData gameData;


    bool isOnlyIgnore = false;
    bool isInfectionIgnore = false;


    bool isPNNull = false;
    bool isPN = false;

    void Start()
    {
        isOnlyIgnore = false;
        isInfectionIgnore = false;

        isPNNull = false;
        isPN = false;


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

        //3�� ���� �ڵ� -> 1�� ���� �ʵ� -> 4�� ������ �ڵ� -> 2�� ������ �ʵ� xx
        //ó�� ���� ���� �ʿ� ȿ�� ���� ī�带 �� ������ �� ��� ���� X
        
        BehaviourCardProcess(behaviourCards[0]._Card);
        SituationCardProcess(fieldCard[0]._Card);

        BehaviourCardProcess(behaviourCards[1]._Card);
        SituationCardProcess(fieldCard[1]._Card);

       

    }


    public void BehaviourCardProcess(BehaviorCard behaviorCard)
    {
        isPN = behaviorCard.PN;
        isPNNull = behaviorCard.cardType == CardType.HandPN;


        if (behaviorCard.OnlyIgnore)  //�̰� �ù� ��ġ ���� �ʿ�
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

        if(!isPNNull)  //���� ���� ���� ī�带 �Ƚ�ٸ� 
        {
            int random = Random.Range(0, 100);

            if (random < 50)
                return;
        }

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

        if (rand < situationCard.pain.Infection_Lever_Per && !isInfectionIgnore)
            gameData.Infection_Level -= situationCard.pain.Infection_Level_Variation;

        rand = Random.Range(0, 100);

        if (rand < situationCard.pain.Energy_Change_Per)
            gameData.Energy -= situationCard.pain.Energy_Change_Volume;


        handCardManager.CardDisPotal(situationCard.pain.CardDispotal);
    }
}

