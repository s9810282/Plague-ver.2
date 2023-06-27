﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;


//[System.Serializable]
//public class CardEvent : ScriptableObject
//{
//    public event System.Action<BehaviorCard> OnCardEvent;
//    public BehaviorCard c;

//    public void PlayCardEvent(BehaviorCard card)
//    {
//        if (OnCardEvent != null)
//            OnCardEvent.Invoke(card);
//    }
//}

public class HandCardManager : MonoBehaviour
{
    public delegate void UAction(BehaviorCard card, bool isZero);

    [SerializeField] BehaviorCard[] cardsDatas;

    [SerializeField] HandCard[] handCards;

    [SerializeField] HandCard showSelectCard;

    [SerializeField] int handCardCount = 0;


    [SerializeField] Transform handCardLimit;

    Action<BehaviorCard> leftSetting;
    Action<BehaviorCard> rightSetting;

    //[Space(30f)]

    public void GameStart()
    {
        for (int i = 0; i < handCardCount; i++)
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
        if (!isZero)
            leftSetting.Invoke(behaviorCard);
        else
            rightSetting.Invoke(behaviorCard);
    }

    public void EventSetting(Action<BehaviorCard> _leftSetting = null, 
        Action<BehaviorCard> _rightSetting = null)
    {
        if (_leftSetting != null)
            leftSetting = _leftSetting;

        if (_rightSetting != null)
            rightSetting = _rightSetting;
    }
}
