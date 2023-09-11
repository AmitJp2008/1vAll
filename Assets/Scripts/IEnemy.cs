public interface IEnemy : IHitable
{
    void Attack();
    void Move();
    bool TargetInRadius();
}

public interface IHitable 
{
    void GotHit(float damageTaken);
    void Die();

}

