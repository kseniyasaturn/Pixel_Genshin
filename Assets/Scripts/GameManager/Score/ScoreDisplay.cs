using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private Text winScoreText;
    [SerializeField] private Text loseScoreText;
    private PointsManager pointsManager; 

    private void Start()
    {
        pointsManager = PointsManager.Instance; 
        UpdateScoreDisplay(); 
    }

    private void Update()
    {
        UpdateScoreDisplay(); 
    }

    private void UpdateScoreDisplay()
    {
        winScoreText.text = " " + pointsManager.GetTotalPoints(); 
        loseScoreText.text = " " + pointsManager.GetTotalPoints(); 
    }
}
