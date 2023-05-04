using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TweenMenuButtons : MonoBehaviour
{

    [Header("Panel Animation")]
    public GameObject menuPanel;

    public float panelDuration = 1f;
    public Ease panelEase = Ease.Flash;

    [Header("Buttons Animation")]
    public List<GameObject> menuButtons;
    public float buttonsDuration = 1f;
    public float buttonsDelay = 1f;
    public Ease buttonsEase = Ease.InElastic;



    public void Awake()
    {
        Init();
    }

    private void Init()
    {
        Hide();
        ShowPanel();
        ShowButtons();
    }

    private void Hide()
    {
        menuPanel.SetActive(false);
        foreach (var b in menuButtons)
        {
            b.SetActive(false);
        }
    }

    private void ShowPanel()
    {
        menuPanel.SetActive(true);
        menuPanel.transform.DOScale(0, panelDuration).SetEase(panelEase).From();
    }

    private void ShowButtons()
    {
        for(int i = 0; i < menuButtons.Count; i ++)
        {
            var b = menuButtons[i];
            b.SetActive(true);
            b.transform.DOScale(0, buttonsDelay).SetEase(buttonsEase).SetDelay(buttonsDelay*(i+1)).From();
        }
    }

}
