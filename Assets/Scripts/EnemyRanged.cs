using System.Drawing;
using UnityEngine;

public class EnemyRanged : EnemyMelee
{
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject enemyBulletPrefab;
    public override void Attack()
    {
        ShootAtTarget();
    }

    private void ShootAtTarget() 
    {
        //Vector3 directionToTarget = Target.position - bulletSpawnPoint.position;
        //Quaternion aimDir = Quaternion.LookRotation(directionToTarget);
        //Instantiate(enemyBulletPrefab, bulletSpawnPoint.position, aimDir);
    }
}

