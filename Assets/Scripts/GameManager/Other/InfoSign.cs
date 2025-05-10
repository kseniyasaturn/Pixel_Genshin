using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoSign : MonoBehaviour
{
   [SerializeField] private GameObject infoPanel; 
   [SerializeField] private float activationDistance;
    private Transform player; 

    private void Start()
    {
        player = GameObject.Find("ArchDemon").transform;
        infoPanel.SetActive(false);
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer <= activationDistance)
        {
            ShowInfoPanel();
        }
        else
        {
            HideInfoPanel();
        }
    }

    private void ShowInfoPanel()
    {
        if (!infoPanel.activeSelf) 
        {
            infoPanel.SetActive(true);
        }
    }

    private void HideInfoPanel()
    {
        if (infoPanel.activeSelf) 
        {
            infoPanel.SetActive(false);
        }
    }
}
