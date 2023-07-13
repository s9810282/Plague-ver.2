using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldCardManager : MonoBehaviour
{
    [SerializeField] SituationCard[] fieldCardDates;

    [SerializeField] FieldCard[] fieldCards;

    [SerializeField] FieldBehaviourCard[] fieldBehaviourCards;

    [SerializeField] Sprite itemIcon;

    [SerializeField] Sprite trueFalseIcon;


    public void GameStart()
    {
        for (int i = 0; i < 2; i++)
        {
            int dataNum = Random.Range(0, fieldCardDates.Length - 1);

            fieldCards[i]._Card = fieldCardDates[dataNum];
            fieldCards[i].SetCardData();
        }
    }

    public void ResetField()
    {
        for (int i = 0; i < 2; i++)
        {
            int dataNum = Random.Range(0, fieldCardDates.Length - 1);

            fieldCards[i]._Card = fieldCardDates[dataNum];
            fieldCards[i].SetCardData();
        }

        fieldBehaviourCards[0].gameObject.SetActive(false);
        fieldBehaviourCards[1].gameObject.SetActive(false);
    }

    public void SetFieldLeft(BehaviorCard behaviorCard = null)
    {
        fieldBehaviourCards[0]._Card = behaviorCard;
        fieldBehaviourCards[0].SetCardData();
        fieldBehaviourCards[0].HandToFieldImage();
        fieldBehaviourCards[0].gameObject.SetActive(true);
    }

    public void SetFieldRight(BehaviorCard behaviorCard = null)
    {
        fieldBehaviourCards[1]._Card = behaviorCard;
        fieldBehaviourCards[1].SetCardData();
        fieldBehaviourCards[1].HandToFieldImage();
        fieldBehaviourCards[1].gameObject.SetActive(true);
    }

    public FieldCard[] ReturnSituationCards()
    {
        return fieldCards;
    }

    public FieldBehaviourCard[] ReturnFieldBehaviourCards()
    {
        return fieldBehaviourCards;
    }    
}
