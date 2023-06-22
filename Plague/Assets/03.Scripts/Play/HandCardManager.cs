using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class HandCardManager : MonoBehaviour
{
    public delegate void UAction(BehaviorCard card, bool isZero);

    [SerializeField] BehaviorCard[] cardsDatas;

    [SerializeField] HandCard[] handCards;

    [SerializeField] HandCard showSelectCard;

    [SerializeField] int handCardCount = 0;

    [SerializeField] Transform handCardLimit;

    [Space(30f)]

    [SerializeField] UnityEvent<BehaviorCard> fieldLeftCardSetting;
    [SerializeField] UnityEvent<BehaviorCard> fieldRightCardSetting;

    [SerializeField] UAction a;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i <  handCardCount; i++)
        {
            handCards[i]._Card = cardsDatas[UnityEngine.Random.Range(0, cardsDatas.Length - 1)];

            handCards[i].ShowSelctCard = showSelectCard;
            handCards[i].SetCardData(SetFieldBehaviour);
            handCards[i].SetLimitPos(handCardLimit);

            handCards[i].gameObject.SetActive(true);
        }
    }

    public void SetFieldBehaviour(BehaviorCard behaviorCard, bool isZero)
    {
        //유니티 이벤트는 GameObject를 상속하는 종류의 변수만 매개변수로 넘겨줄수 있어서 ScriptableObject인 카드 정보는 안됨
        //
        Debug.Log("Setting");
        Debug.Log(behaviorCard.GetType());
        Debug.Log(behaviorCard.cardName);
        Debug.Log(isZero);

        if (!isZero)
            fieldLeftCardSetting.Invoke(behaviorCard);
        else
            fieldRightCardSetting.Invoke(behaviorCard);
    }
}
