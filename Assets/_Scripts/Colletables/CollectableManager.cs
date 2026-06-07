using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{
    public SOint Coins;
    public TextMeshProUGUI uiTextCoins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        Coins.value = 0;
        UpdateUI();
    }

    public void AddCoins(int amount = 1)
    {
        Coins.value += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        //uiTextCoins.text = Coins.ToString();
        //UiGameManager.UpdateTextCoins(Coins.value.ToString());
    }
}
