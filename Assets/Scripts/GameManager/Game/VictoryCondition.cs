using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryCondition : MonoBehaviour
{
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private PlayerManager playerManager;

    private void Start()
    {
        victoryPanel.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            victoryPanel.SetActive(true);
            pauseButton.SetActive(false);
            playerManager.MovingOff();
        }
    }
}
