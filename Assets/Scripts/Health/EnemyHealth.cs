using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] protected int points;
    public override int GetPoints() => points;
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        CheckIsEnemyDead();
    }

    public override void CheckIsEnemyDead()
    {     
        base.CheckIsEnemyDead();
    }
}
