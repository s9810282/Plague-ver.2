using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;
using System;

public class HandCard : MonoBehaviour, IPointerClickHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] RectTransform handCard;

    [SerializeField] Text itemTypeText;

    [SerializeField] Text itemNameText;

    [SerializeField] Image itemImage;

    [SerializeField] Text itemAbilityText;

    Action<BehaviorCard, bool> cardSetting;

    private BehaviorCard card;
    public BehaviorCard _Card { get { return card; } set { card = value; } }

    private HandCard showSelectCard;
    public HandCard ShowSelctCard { get { return showSelectCard; } set { showSelectCard = value; } }

    Transform limitPos;

    bool isShowCard = false;

    Vector3 startpos;

    // Start is called before the first frame update
    void Start()
    {
        
    }
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

    public void SetCardData(Action<BehaviorCard, bool> action = null)
    {
        itemTypeText.text = _Card.cardType.ToString();
        itemNameText.text = _Card.cardName.ToString();

        itemImage.sprite = _Card.sprite;
        itemAbilityText.text = _Card.cardAbility;

        if (action != null)
            cardSetting = action;

    } //카드 정보 적용


    public void CardClear()
    {
        gameObject.SetActive(false);
    }

    public void SetLimitPos(Transform pos)
    {
        limitPos = pos;
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
        if (transform.position.y > limitPos.position.y)
        {
            CardClear();

            if (cardSetting != null)
                cardSetting.Invoke(card, transform.position.x > limitPos.position.x);

            Debug.Log(transform.position.x);
            Debug.Log(limitPos.position.x);
        }
        else
            transform.position = startpos;
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
