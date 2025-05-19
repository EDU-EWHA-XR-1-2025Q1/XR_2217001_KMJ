using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMover : MonoBehaviour
{
    public float moveRadius = 0.05f; // AR에서는 5cm 권장
    public Vector3 centerLocalPos = new Vector3(0, 0.1f, 0);

    private float timer = 0f;
    private float nextMoveTime;

    void Start()
    {
        ScheduleNextMove();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextMoveTime)
        {
            MoveToRandomPosition();
            ScheduleNextMove();
        }
    }

    void ScheduleNextMove()
    {
        timer = 0f;
        nextMoveTime = Random.Range(0.5f, 1f);
    }

    void MoveToRandomPosition()
    {
        Vector3 randomOffset = new Vector3(
            Random.Range(-moveRadius, moveRadius),
            Random.Range(-moveRadius * 0.5f, moveRadius * 0.5f),
            Random.Range(-moveRadius, moveRadius)
        );

        transform.localPosition = centerLocalPos + randomOffset;
    }
}



