using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt life;

    protected override void Awake()
    {
        base.Awake();
        
        Reset();
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

    public void AddLife(int amount =1)
    {
        life.AddValue(amount);
    }
}
