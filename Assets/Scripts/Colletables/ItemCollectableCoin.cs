using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public Collider collider;

    protected override void OnCollect()
    {
        base.OnCollect();
        CollectableManager.Instance.AddCoins();
        collider.enabled = false;
    }
}
