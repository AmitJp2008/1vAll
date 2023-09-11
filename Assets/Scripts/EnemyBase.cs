using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    private const float timeToSelfDestrcut = 2f;
    
    [SerializeField] private EnemyData enemyData;
    [SerializeField] private GameObject enemyModel;
    private Transform target;
    public float CurrentHealth;
    public float CurrentDamage;

    public Transform Target => target;
    public EnemyData EnemyData => enemyData;

    private void Awake()
    {
        SetEnemyHealth(enemyData.Health);
        SetEnemyDamage(enemyData.Damage);
        target = PlayerTransformGetter.Instance.Player;
        gameObject.name = enemyData.EnemyName;
        gameObject.tag = "Enemy";

        if (enemyModel != null) 
        {
            enemyModel.tag = "Enemy";
        }
    }

    public abstract void Attack();

    public virtual void Die() 
    {
        gameObject.SetActive(false);
        Destroy(gameObject, timeToSelfDestrcut);
    }

    public abstract void GotHit(float damageTaken);

    public abstract void Move();
    
    public void SetEnemyHealth(float health) 
    {
        CurrentHealth = health;
    }
    public void SetEnemyDamage(float damage)
    {
        CurrentDamage = damage;
    }

    public virtual bool TargetInRadius() 
    {
        return GameplayHelper.IsPointInsideSphere(Target.position, transform.position, EnemyData.DistanceOfAttack);
    }
}

