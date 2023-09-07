using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    private const float timeToSelfDestrcut = 2f;
    
    [SerializeField] private EnemyData enemyData;
    private Transform target;
    public int CurrentHealth;
    public Transform Target => target;
    public EnemyData EnemyData => enemyData;

    private void Awake()
    {
        CurrentHealth = EnemyData.Health;
        target = PlayerTransformGetter.Instance.Player;
    }

    public abstract void Attack();

    public virtual void Die() 
    {
        gameObject.SetActive(false);
        Destroy(gameObject, timeToSelfDestrcut);
    }

    public abstract void GotHit(int damageTaken);

    public abstract void Move();

    public virtual bool TargetInRadius() 
    {
        return GameplayHelper.IsPointInsideSphere(Target.position, transform.position, EnemyData.DistanceOfAttack);
    }
}

