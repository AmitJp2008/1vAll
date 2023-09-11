using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletControllerBase : MonoBehaviour 
{
    [SerializeField] private string effectiveTag;
    [SerializeField] private float bulletSpeed = 20f;

    private const float distanceFromCenterOfGame = 50f;
    
    private Rigidbody bulletRigidbody;
    private float bulletDamage;
    
    public string EffectiveTag => effectiveTag;
    public float BulletDamage => bulletDamage;
    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }
    private void Update()
    {
        if (distanceFromCenterOfGame < Mathf.Abs(transform.position.x) || distanceFromCenterOfGame < Mathf.Abs(transform.position.y) || distanceFromCenterOfGame < Mathf.Abs(transform.position.z))
        {
            Destroy(gameObject);
        }
    }
    public void SetBulletDamage(float damageOnHit)
    {
        bulletDamage = damageOnHit;
    }
    private void OnTriggerEnter(Collider other)
    {
        OnBulletCollision(other);
    }

    public virtual void OnBulletCollision(Collider other) 
    {
        if (other.gameObject.tag == effectiveTag) 
        {
            GameplayEvents.Instance.TargetGotHit?.Invoke(other.gameObject, bulletDamage);
        }

        Destroy(gameObject);
    }
}
