using UnityEngine;

[CreateAssetMenu(fileName = "New enemy data", menuName = "Gameplay/EnemyData")]
public class EnemyData : ScriptableObject 
{
    [SerializeField] private GameObject bloodVfx;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private int killPoints;
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private float distanceOfAttack;
    [SerializeField] private float attackSpeed;
    [SerializeField] private float movementSpeed;

    public GameObject BloodVfx => bloodVfx;
    public AudioClip HitSound => hitSound;
    public int KillPoints => killPoints;
    public int Health => health;
    public int Damage => damage;
    public float DistanceOfAttack => distanceOfAttack;
    public float AttackSpeed => attackSpeed;
    public float MovementSpeed => movementSpeed;
}

