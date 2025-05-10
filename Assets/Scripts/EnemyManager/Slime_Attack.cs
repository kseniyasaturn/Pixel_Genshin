using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Slime_Attack : MonoBehaviour
{
    public float moveSpeed = 3f;  
    public float detectionRadius = 5f; 
    private Transform player;           
    private bool playerInRange = false; 
    [SerializeField] private UnityEvent OnAttack;
    [SerializeField] private UnityEvent OnIdle;

    private void Start()
    {
        player = GameObject.Find("ArchDemon").transform; 
    }

    private void Update()
    {
        if (playerInRange)
        {
            MoveTowardsPlayer(); 
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime; 
        OnAttack?.Invoke();
        if (Vector3.Distance(transform.position, player.position) > detectionRadius) playerInRange = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            OnIdle?.Invoke();
        }
    }
}

