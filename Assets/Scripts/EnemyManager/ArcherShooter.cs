using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShooter : MonoBehaviour
{
    [SerializeField] private Transform player; // ������ �� ������
    [SerializeField] private GameObject arrowPrefab; // ������ ������
    [SerializeField] private Transform firePoint; // �����, �� ������� ������ ����� �����������
    [SerializeField] private float shootingRate = 2.0f; // �������� ��������
    private bool isPlayerInRange = false;

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Time.frameCount % Mathf.FloorToInt(60f / shootingRate) == 0)
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Health>(out var health))
        {
            isPlayerInRange = false;
        }
    }

    private void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - firePoint.position).normalized; 
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * arrow.GetComponent<Arrow>().damage; 
        }
    }
}

