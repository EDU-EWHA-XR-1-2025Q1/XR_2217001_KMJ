using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    void OnMouseDown()
    {
        if (GameManager.Instance.remainingItems > 0)
        {
            GameManager.Instance.IncreasePickCount();
            Destroy(gameObject);
        }
    }
}

