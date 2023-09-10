using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : EnemyBase
{
    private float attackTimer = 0f;
    private float attackCooldown => 1f / EnemyData.AttackSpeed; // Calculate cooldown based on frequency
    bool targetInRadius = false;

    // Update is called once per frame
    void Update()
    {
        attackTimer += Time.deltaTime;
        if (targetInRadius) 
        {
            if (attackTimer >= attackCooldown) 
            {
                Attack();
                attackTimer = 0;
            }
        }
        if (CurrentHealth <= 0) 
        {
            Die();
        }
    }
    private void FixedUpdate()
    {
        Vector3 aimDir = (Target.position - transform.position);
        aimDir.y = 0; // Ignore height difference for rotation

        Quaternion rotation = Quaternion.LookRotation(aimDir);
        transform.rotation = Quaternion.Euler(0, rotation.eulerAngles.y, 0);

        targetInRadius = TargetInRadius();
        if (!targetInRadius) 
        {
            Move();
        }
    }
    public override void Attack()
    {
        Debug.Log($"Enemy {gameObject.name} attacked player");
    }

    public override void Die()
    {
        GameplayEvents.Instance.EnemyDied?.Invoke(gameObject);
        base.Die();
    }

    public override void Move()
    {
        // Move towards the target
        Vector3 newPosition = Vector3.MoveTowards(transform.position, Target.position, EnemyData.MovementSpeed);
        transform.position = newPosition;
    }
    public override void GotHit(float damageTaken)
    {
        CurrentHealth -= damageTaken;
        // play hit effect and sound
    }
}

