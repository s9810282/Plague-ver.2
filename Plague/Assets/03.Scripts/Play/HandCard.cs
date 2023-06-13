using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using System;

public class HandCard : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Text itemTypeText;

    [SerializeField] Text itemNameText;

    [SerializeField] Image itemImage;

    [SerializeField] Text itemAbilityText;


    private BehaviorCard card;
    public BehaviorCard _Card { get { return card; } set { card = value; } }

    private HandCard showSelectCard;
    public HandCard ShowSelctCard { get { return showSelectCard; } set { showSelectCard = value; } }

    float limitYPos = 0f;

    bool isShowCard = false;

    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isShowCard)
        {
            if(Input.GetMouseButtonDown(0))
            {
                isShowCard = false;
                showSelectCard.gameObject.SetActive(false);
            }
        }
    }

    public void SetCardData()
    {
        itemTypeText.text = _Card.cardType.ToString();
        itemNameText.text = _Card.cardName.ToString();

        itemImage.sprite = _Card.sprite;
        itemAbilityText.text = _Card.cardAbility;
    } //카드 정보 적용


    public void SetLimitYPos(float yPos)
    {
        limitYPos = yPos;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        startpos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startpos;

        Debug.Log(eventData.position);
        Debug.Log(eventData.worldPosition);
        Debug.Log(gameObject.transform.position);
        Debug.Log(gameObject.transform.localPosition);
    }

    public void OnPointerClick(PointerEventData eventData) //더블클릭 시 카드 확대
    {
        if (eventData.clickCount >= 2)
        {
            isShowCard = true;

            showSelectCard.card = card;
            showSelectCard.SetCardData();

            showSelectCard.gameObject.SetActive(true);
        }
    }
}
