using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldBehaviourCard : MonoBehaviour
{
    [SerializeField] Text itemTypeText;

    [SerializeField] Text itemNameText;

    [SerializeField] Image itemImage;

    [SerializeField] Text itemAbilityText;

    [SerializeField] Image iconImage;

    private BehaviorCard card;
    public BehaviorCard _Card { get { return card; } set { card = value; } }

    // Start is called before the first frame update
    void Start()
    {

    }


    public void SetCardData()
    {
        itemTypeText.text = card.cardType.ToString();
        itemNameText.text = card.cardName.ToString();

        itemImage.sprite = card.sprite;
        iconImage.sprite = card.icon;

        itemAbilityText.text = card.cardAbility;
    }

    public void HandToFieldImage()
    {
        itemImage.sprite = card.fieldSprite;
    }
}
