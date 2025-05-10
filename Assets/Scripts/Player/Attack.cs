using System;
using UnityEngine;

public class Attack : MonoBehaviour, IAttack
{
    [SerializeField] private float damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Health>(out var health))
        {            
            health.TakeDamage(damage);           
        }
    }
}