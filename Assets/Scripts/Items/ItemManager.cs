using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public CoinsTracker coinsTracker;

    public int coins;

    protected override void Awake()
    {
        base.Awake();
        
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        coinsTracker.UpdateText(coins);
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinsTracker.UpdateText(coins);
    }
}
