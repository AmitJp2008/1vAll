public interface IEnemy 
{
    void Attack();
    void Move();
    void Die();
    void GotHit(float damageTaken);
    bool TargetInRadius();
}

