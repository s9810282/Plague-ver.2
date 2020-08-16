using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class IntroManager : MonoBehaviour
{
    [SerializeField] [TextArea] string[] introTexts;

    [SerializeField] Text introText;

    [SerializeField] Image fadeImage;

    bool isDoText = false;

    Coroutine textCoroutine;

    void Awake()
    {
        isDoText = false;

        fadeImage.DOFade(0, 2.5f).OnComplete(() => fadeImage.gameObject.SetActive(false));
                                                   textCoroutine = StartCoroutine(Texting());
    }

    public void Skip()
    {
        introText.DOKill();
        StopCoroutine(textCoroutine);

        fadeImage.DOFade(1, 2f).OnStart(() => fadeImage.gameObject.SetActive(true))
                                .OnComplete(() => SceneManager.LoadScene("Play"));
    }

    IEnumerator Texting()
    {
        for (int i = 0; i < introTexts.Length; i++)
        {
            introText.DOKill();

            isDoText = false;

            introText.text = null;
            introText.DOText(introTexts[i], introTexts[i].Length * 0.1f)
                            .SetEase(Ease.Linear)
                            .OnComplete(() => isDoText = true)
                            .Restart();

            yield return new WaitUntil(() => isDoText);
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));  
        }

        Skip();
    }
}
