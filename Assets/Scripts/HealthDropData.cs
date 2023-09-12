using UnityEngine;

[CreateAssetMenu(fileName = "Health drop data", menuName = "Gameplay/Heath Drop")]
public class HealthDropData : ScriptableObject 
{
    [SerializeField] private GameObject healthDropPrefab;
    [SerializeField] private float healAmount;
    public GameObject HealthDropPrefab => healthDropPrefab;
    public float HealAmount => healAmount;
}
