using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float damage = 10f; 
    [SerializeField] private float lifetime = 5f; 

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            health.TakeDamage(damage); 
            Destroy(gameObject); 
        }
    }
}
