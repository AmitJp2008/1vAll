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

    private void OnEnable()
    {
        GameplayEvents.Instance.BulletCollidedWithTarget += PlayBloodEffect;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.BulletCollidedWithTarget -= PlayBloodEffect;

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
    public void PlayBloodEffect(Collider collider, Vector3 bulletHitPoint) 
    {
        if (collider.gameObject == enemyModel) 
        {
            //also check if allowed to play blood here

            // Approximate the point of contact by finding the closest point on the enemy's collider to the bullet
            Vector3 pointOfContact = collider.ClosestPoint(bulletHitPoint);

            // Use the direction from the enemy to the bullet as an approximation for the collision normal
            Vector3 approximateNormal = (enemyModel.transform.position - pointOfContact).normalized;

            // Calculate the direction opposite to the bullet's movement
            Vector3 bloodEffectDirection = enemyModel.transform.forward; // Assuming the bullet's forward direction is its movement direction

            // Make sure the blood effect direction is orthogonal to the normal
            bloodEffectDirection = Vector3.ProjectOnPlane(bloodEffectDirection, approximateNormal).normalized;

            Instantiate(enemyData.BloodVfx, pointOfContact, Quaternion.LookRotation(bloodEffectDirection));

        }
    }
    public virtual bool TargetInRadius() 
    {
        return GameplayHelper.IsPointInsideSphere(Target.position, transform.position, EnemyData.DistanceOfAttack);
    }
}

