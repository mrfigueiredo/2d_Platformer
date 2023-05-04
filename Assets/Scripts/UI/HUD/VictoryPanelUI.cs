using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryPanelUI : MonoBehaviour
{
    public ItemManager itemManager;
    public TextMeshProUGUI coinsCollectedText;
    public TextMeshProUGUI coinsTotalText;
    public TextMeshProUGUI lifesCollectedText;
    public TextMeshProUGUI lifesTotalText;
    public TextMeshProUGUI totalCompletionText;

    public void CompleteUI()
    {
        SetCoinsHUD();
        SetLifeHUD();
        LevelCompletionText();
    }

    public void SetCoinsHUD()
    {
        coinsCollectedText.text = itemManager.GetCollectedCoins().ToString();
        coinsTotalText.text = itemManager.GetTotalCoins().ToString();
    }

    public void SetLifeHUD()
    {
        lifesCollectedText.text = itemManager.GetCollectedLifes().ToString();
        lifesTotalText.text = itemManager.GetTotalLifes().ToString();
    }

    public void LevelCompletionText()
    {
        totalCompletionText.text = itemManager.LevelCompletionPercentage().ToString() + "%";
    }
}
