using UnityEngine;
using UnityEngine.UI;


public class UpdateHealth : MonoBehaviour, IUpdateHealth
{
    [SerializeField] private GameObject CanvasHealth;
    [SerializeField] private Image healthBar;
    private Health playerHealth;

    private void Update()
    {         
        CanvasHealth.transform.LookAt(Camera.main.transform);
        CanvasHealth.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
    }

    public void UpdateHealthBar(float currentHealth)
    {
        healthBar.fillAmount = currentHealth / 100f;
    }
}
