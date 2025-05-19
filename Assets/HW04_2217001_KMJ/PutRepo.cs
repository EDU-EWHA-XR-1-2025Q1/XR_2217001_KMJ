using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutRepo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            GameManager.Instance.IncreasePutCount();
            Destroy(other.gameObject);
        }
    }
}

