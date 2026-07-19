using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using core.Singleton;

public class CollectableManager : Singleton<CollectableManager>
{
    public SOint Coins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        Coins.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        Coins.value += amount;
    }
}

