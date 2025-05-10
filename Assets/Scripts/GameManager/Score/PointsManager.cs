using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    public static PointsManager Instance;
    private int totalPoints;

    private void Awake()
    {
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

    public void AddPoints(int points)
    {
        totalPoints += points;
        Debug.Log($"Total Points: {totalPoints}");
    }

    public int GetTotalPoints()
    {
        return totalPoints;
    }
}
