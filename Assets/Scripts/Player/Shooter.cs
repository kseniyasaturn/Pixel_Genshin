
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Bullet bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private UnityEvent OnAttack;

    [SerializeField] private int maxAmmo;
    [SerializeField] private int currentAmmo;
    [SerializeField] private float reloadTime = 2f;
    
    [SerializeField] private UnityEvent OnReload;
    [SerializeField] private Text ammoText;

    [SerializeField] private ParticleSystem bulletHitEggectPrefab;

    private void Start()
    {
        currentAmmo = maxAmmo;
        UpdateAmmoDisplay();
        bulletHitEggectPrefab.Stop();
    }
    public void Shoot()
    {
        if (currentAmmo > 0)
        {
            Bullet currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);         
            currentBullet.SetDirection(playerMovement.FaceRight);
            if (bulletHitEggectPrefab != null)
            {
                bulletHitEggectPrefab.transform.position = firePoint.position;
                bulletHitEggectPrefab.Play();
            }
            else { Debug.LogWarning("bulletHitEggectPrefab is null!"); }

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayShootSound();
            }
            else Debug.LogWarning("AudioManager instance in null!");
            currentAmmo--;
            UpdateAmmoDisplay();
            OnAttack?.Invoke();
        }
        else
        {
            Debug.Log("No ammo!");
        }
    }

    public void Reload()
    {
        if (currentAmmo < maxAmmo)
        {
            StartCoroutine(ReloadCoroutine());
        }
    }
    private IEnumerator ReloadCoroutine()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        OnReload?.Invoke();
        Debug.Log("Reloaded!");
        UpdateAmmoDisplay();
    }

    private void UpdateAmmoDisplay()
    {
       ammoText.text = $"{currentAmmo} / {maxAmmo}";
    }
}
