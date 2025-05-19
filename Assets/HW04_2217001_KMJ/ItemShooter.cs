using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShooter : MonoBehaviour
{
    public GameObject itemPrefab; 
    public Transform firePoint; 
    public float fireForce = 500f;

    public void Fire()
    {
        if (GameManager.Instance.pickCount > 0)
        {
            GameManager.Instance.pickCount--;

            GameObject item = Instantiate(itemPrefab, firePoint.position, Quaternion.identity);

            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = item.AddComponent<Rigidbody>();
            }

            
            rb.isKinematic = false;
            rb.useGravity = true;


            Vector3 fireDirection = Camera.main.transform.forward + Camera.main.transform.up * 0.5f;
            rb.AddForce(fireDirection.normalized * fireForce, ForceMode.Force);
        }
    }

}
