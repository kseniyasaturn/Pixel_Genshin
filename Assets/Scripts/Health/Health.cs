
using UnityEngine;
using UnityEngine.Events;

public abstract class Health : MonoBehaviour, IDamaged, IPlayerDead, IEnemyDead, IHealed
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    public bool IsDead = false; 

    [Header("Events")]
    [SerializeField] private UnityEvent<float> HealthChanged;
    [SerializeField] private UnityEvent OnDeathEvent;
    [SerializeField] private UnityEvent OnDamage;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        OnDamage?.Invoke();
        HealthChanged?.Invoke(currentHealth);
    }
    public abstract int GetPoints();
    public virtual void CheckIsPlayerDead()
    {
        if (currentHealth <= 0)
        {
            IsDead = true;
            OnDeathEvent?.Invoke();
        }
    }

    public virtual void CheckIsEnemyDead()
    {
        if (currentHealth <= 0)
        {
            IsDead = false;            
            Destroy(gameObject);
            PointsManager.Instance.AddPoints(GetPoints());
        }
    }

    public virtual void HealPlayer(float healAmount)
    {
        if(currentHealth == maxHealth)
        {
            return;
        }
        currentHealth += healAmount;
        if (currentHealth > maxHealth) { currentHealth = maxHealth;}
        HealthChanged?.Invoke(currentHealth);
    }
}
    

