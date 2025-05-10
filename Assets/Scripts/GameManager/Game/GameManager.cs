using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }
    public void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
