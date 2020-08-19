using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.EventSystems;

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
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startpos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Drag");
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startpos;
    }

    public void OnPointerClick(PointerEventData eventData)
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
