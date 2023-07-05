using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEventManager : MonoBehaviour
{
    /// <summary>
    /// ¤¸°°´Ù
    /// </summary>
    /// 

    [SerializeField] FieldCardManager fieldCardManager;

    [SerializeField] HandCardManager handCardManager;

    [SerializeField] GameData gameData;

    // Start is called before the first frame update
    void Start()
    {
        FiedlEventSetting();

        fieldCardManager.GameStart();
        handCardManager.GameStart();
    }

    public void FiedlEventSetting()
    {
        handCardManager.EventSetting(fieldCardManager.SetFieldLeft, fieldCardManager.SetFieldRight);
    }


    public void CardSettingEnd()
    {
        ClosingFieldCard();
        gameData.CheckEnding();
    }

    public void ClosingFieldCard()
    {

    }
}
