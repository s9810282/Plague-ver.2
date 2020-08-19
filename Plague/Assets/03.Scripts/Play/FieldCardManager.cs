using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldCardManager : MonoBehaviour
{
    [SerializeField] SituationCard[] fieldCardDates;

    [SerializeField] FieldCard[] fieldCards;

    [SerializeField] Sprite itemIcon;

    [SerializeField] Sprite trueFalseIcon;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 2; i++)
        {
            int dataNum = Random.Range(0, fieldCardDates.Length - 1);

            fieldCards[i]._Card = fieldCardDates[dataNum];
   

            fieldCards[i].SetCardData();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
