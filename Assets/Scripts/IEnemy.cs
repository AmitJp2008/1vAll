public interface IEnemy 
{
    void Attack();
    void Move();
    void Die();
    void GotHit(int damageTaken);
    bool TargetInRadius();
}

