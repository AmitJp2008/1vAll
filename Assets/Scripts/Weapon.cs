using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Gameplay/Weapon Data")]
public class Weapon : ScriptableObject
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Sprite weaponCrosshair;
    [SerializeField] private Sprite weaponImage;
    [SerializeField] private int ammunationAmount;
    [SerializeField] private float damagePerHit;
    [SerializeField] private AudioClip shotSound;
    [SerializeField, Tooltip("if more then zero the weapon can be shot holding the shooting button")] private float shootFrequency;

    public GameObject Bullet => bulletPrefab;
    public Sprite Crosshair => weaponCrosshair;
    public Sprite WeaponImage => weaponImage;
    public int AmmunationAmount => ammunationAmount;
    public AudioClip ShotSound => shotSound;
    public float ShootFrequency => shootFrequency;
}