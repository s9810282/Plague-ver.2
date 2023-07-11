using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using DG.Tweening;

public class TitleManager : MonoBehaviour
{
    [SerializeField] Image fadeImage;

    void Awake()
    {
        fadeImage.DOFade(0, 2.5f).OnComplete(() => fadeImage.gameObject.SetActive(false));
    }

    public void StartGame()
    {
        fadeImage.DOFade(1, 2f).OnStart(() => fadeImage.gameObject.SetActive(true))
                                 .OnComplete(() => SceneManager.LoadScene("Loading"));
    }

    public void Exit()
    {
        Application.Quit();
    }
}


