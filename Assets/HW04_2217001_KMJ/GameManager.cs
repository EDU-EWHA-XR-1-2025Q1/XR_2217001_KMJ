using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // 싱글톤

    public int pickCount = 0;
    public int putCount = 0;

    public int totalItems = 10; // 전체 Item 수 (처음 고정값)
    public int remainingItems = 10; // 남은 Item 수 (처음 10)

    private void Awake()
    {
        // 싱글톤 중복 방지
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncreasePickCount()
    {
        pickCount++;

        if (remainingItems > 0)
        {
            remainingItems--;
        }
    }

    public void IncreasePutCount()
    {
        putCount++;
    }
}
