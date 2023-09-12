using System.Drawing;
using UnityEngine;

public class EnemyRanged : EnemyMelee
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject enemyBulletPrefab;

    private Transform aimPoint;
    private void Start()
    {
        aimPoint = PlayerTransformGetter.Instance.PlayerAimPoint;
    }
    public override void Attack()
    {
        ShootAtTarget();
    }

    private void ShootAtTarget() 
    {
        Vector3 directionToTarget = aimPoint.position - bulletSpawnPoint.position;
        Quaternion aimDir = Quaternion.LookRotation(directionToTarget);
        if (Instantiate(enemyBulletPrefab, bulletSpawnPoint.position, aimDir).TryGetComponent(out BulletControllerBase bullet)) 
        {
            bullet.SetBulletDamage(EnemyData.Damage);
        }
    }
}

