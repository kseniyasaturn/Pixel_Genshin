using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : Health
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        CheckIsPlayerDead();
    }

    public override void CheckIsPlayerDead()
    {
        base.CheckIsPlayerDead();
    }

    public override void HealPlayer(float healAmount)
    {
        base.HealPlayer(healAmount);
    }
    public override int GetPoints()
    {
        return 0;
    }
}
