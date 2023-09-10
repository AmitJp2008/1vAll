using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplyer : MonoBehaviour
{
    private Transform player;
    private float overallDamageAgainstPlayer = 0;
    private float overallDamageAgainstEnemies = 0;

    private void OnEnable()
    {
        GameplayEvents.Instance.BulletHitEnemy += DamageEnemy;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.BulletHitEnemy -= DamageEnemy;

    }

    private void DamageEnemy(GameObject enemyObj, float damageToApply)
    {
        if (enemyObj == null) return;

        EnemyBase enemy = enemyObj.transform.parent.gameObject.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            enemy.GotHit(damageToApply);
            overallDamageAgainstEnemies += damageToApply;
        }
        else
            Debug.LogError($"DamageEnemy: Enemy {enemyObj} has no enemy base class on him - error");
    }
}
