using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardManager : MonoBehaviour
{
    [SerializeField] BehaviorCard[] cardsDatas;

    [SerializeField] HandCard[] handCards;

    [SerializeField] HandCard showSelectCard;

    [SerializeField] int handCardCount = 0;

    [SerializeField] float handCardLimitY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i <  handCardCount; i++)
        {
            handCards[i]._Card = cardsDatas[Random.Range(0, cardsDatas.Length - 1)];

            handCards[i].ShowSelctCard = showSelectCard;
            handCards[i].SetCardData();
            handCards[i].SetLimitYPos(handCardLimitY);

            handCards[i].gameObject.SetActive(true);          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
