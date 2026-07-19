using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";

    public float timeToHide = 3;
    public GameObject graphicItem;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag(compareTag))
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        OnCollect();
    }

    protected void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (graphicItem != null)
            graphicItem.SetActive(false);

        Invoke(nameof(HideObject), timeToHide);
    }
}

