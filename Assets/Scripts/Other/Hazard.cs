using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
   [SerializeField] private int damageAmount; 
   [SerializeField] private float damageInterval = 2f; 
    private bool isPlayerInHazard = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            isPlayerInHazard = true;
            StartCoroutine(DamagePlayer(collision.GetComponent<PlayerHealth>()));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            isPlayerInHazard = false;
        }
    }

    private IEnumerator DamagePlayer(PlayerHealth playerHealth)
    {
        while (isPlayerInHazard)
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
            yield return new WaitForSeconds(damageInterval); 
        }
    }
}
