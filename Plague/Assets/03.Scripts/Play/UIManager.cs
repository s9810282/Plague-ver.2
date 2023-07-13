using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text daysText;
    [SerializeField] Image energy;
    [SerializeField] Image infection;

    [Space(30f)]

    [SerializeField] GameObject fadeCanvas;
    [SerializeField] Image fadeImage;
    [SerializeField] Text fadeText;

    [Space(30f)]

    [SerializeField] GameData gameData;

    void Start()
    {
        FadeDays();
    }

    public void ModifyDataText()
    {
        daysText.text = gameData.Days + " ÀÏÂ÷";
        energy.fillAmount = (float)gameData.Energy / (float)gameData.MaxEnergy;
        infection.fillAmount = (float)gameData.Infection_Level / (float)gameData.MaxInfection_Level;

        fadeText.text = "DAYS - " + gameData.Days;
    }

    public void FadeDays()
    {
        fadeImage.color = Color.black;
        fadeText.color = Color.white;

        fadeCanvas.gameObject.SetActive(true);
        fadeText.gameObject.SetActive(true);
        fadeImage.gameObject.SetActive(true);

       
        fadeImage.DOFade(0, 2.5f).OnComplete(() => fadeImage.gameObject.SetActive(false));
        fadeText.DOFade(0, 2.5f).OnComplete(() => fadeText.gameObject.SetActive(false)); 
    }
}
