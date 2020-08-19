using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldCard : MonoBehaviour
{
    [SerializeField] Text itemTypeText;

    [SerializeField] Text itemNameText;

    [SerializeField] Image itemImage;

    [SerializeField] Text itemAbilityText;

    [SerializeField] Image iconImage;

    private SituationCard card;
    public SituationCard _Card { get { return card; } set { card = value; } }

    Rect rect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void SetCardData()
    {
        itemTypeText.text = _Card.cardType.ToString();
        itemNameText.text = _Card.cardName.ToString();

        iconImage.sprite = _Card.icon;
        itemImage.sprite = _Card.sprite;

        itemAbilityText.text = _Card.cardAbility;
    }
}
