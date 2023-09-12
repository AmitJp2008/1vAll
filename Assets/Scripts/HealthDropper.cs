using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropper : MonoBehaviour
{
    [SerializeField] private float dropChance = 0.1f;
    [SerializeField] private HealthDropData healthDropData;
    private void OnEnable()
    {
        GameplayEvents.Instance.EnemyDied += DropHealth;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.EnemyDied -= DropHealth;
    }

    private void DropHealth(EnemyBase enemy) 
    {
        float rand = Random.Range(0, 1f);
        if (rand <= dropChance) 
        {
            CreateHealthDrop(enemy.transform.position);
        }
    }

    private void CreateHealthDrop(Vector3 dropPos) 
    {
        GameObject healthDropObj = Instantiate(healthDropData.HealthDropPrefab, dropPos, Quaternion.identity);

        if (healthDropObj.TryGetComponent(out HealthGlobe healthComponent)) 
        {
            healthComponent.SetHealthGlobe(healthDropData.HealAmount);
        }
    }
}