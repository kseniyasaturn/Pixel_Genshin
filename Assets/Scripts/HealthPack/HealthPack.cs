using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private float healAmount;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {
            health.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
