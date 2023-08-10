using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    public string cardName;
    public CardType cardType;

    public Sprite sprite;
    public Sprite icon;

    [TextArea] public string cardAbility;
    
}


