using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt life;

    public GameObject coinsHolder;
    public GameObject lifesHolder;

    private int _totalCoins;
    private int _totalLifes;

    protected override void Awake()
    {
        base.Awake();

        Reset();

        _totalCoins = coinsHolder.transform.childCount;
        _totalLifes = lifesHolder.transform.childCount;
    }

    private void Reset()
    {
        coins.SetValue(0);
        life.SetValue(0);
    }

    public void AddCoins(int amount = 1)
    {
        coins.AddValue(amount);
    }

    public void AddLife(int amount = 1)
    {
        life.AddValue(amount);
    }

    public int GetCollectedCoins()
    {
        return coins.GetValue();
    }

    public int GetCollectedLifes()
    {
        return life.GetValue();
    }

    public int GetTotalCoins()
    {
        return _totalCoins;
    }

    public int GetTotalLifes()
    {
        return _totalLifes;
    }

    public int LevelCompletionPercentage()
    {
        float total = ((float)(coins.GetValue() + life.GetValue()) / (float)(_totalCoins + _totalLifes)) * 100f;
        return (int)total;
    }
}
