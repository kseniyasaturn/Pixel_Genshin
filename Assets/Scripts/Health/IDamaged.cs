internal interface IDamaged
{
    void TakeDamage(float damage);
}

internal interface IPlayerDead
{
    void CheckIsPlayerDead();
}

internal interface IEnemyDead
{
    void CheckIsEnemyDead();
}

internal interface IHealed
{
    void HealPlayer(float healAmount);
}


