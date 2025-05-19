using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform parentTarget; // CylinderTarget

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        CapsuleCollider cylinderCollider = parentTarget.GetComponent<CapsuleCollider>();
        if (cylinderCollider == null)
        {
            Debug.LogError("CylinderTarget에 CapsuleCollider가 필요합니다.");
            return;
        }

        float radiusMin = cylinderCollider.radius - 0.01f;
        float radiusMax = cylinderCollider.radius + 0.02f;
        float height = cylinderCollider.height;

        for (int i = 0; i < GameManager.Instance.remainingItems; i++)
        {
            float angle = Random.Range(0f, 360f);

            float randomRadius = Random.Range(radiusMin, radiusMax);

            Vector3 offset = new Vector3(
                Mathf.Cos(angle * Mathf.Deg2Rad) * randomRadius,
                0f,
                Mathf.Sin(angle * Mathf.Deg2Rad) * randomRadius
            );

            float yPos = parentTarget.position.y + Random.Range(-height * 0.25f, height * 0.25f);

            Vector3 spawnPos = new Vector3(parentTarget.position.x, yPos, parentTarget.position.z) + offset;

            GameObject item = Instantiate(itemPrefab, spawnPos, Quaternion.identity, parentTarget);

            item.transform.LookAt(parentTarget.position);
        }
    }






}
