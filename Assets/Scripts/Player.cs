using System.Resources;
using UnityEngine;

public class Player : MonoBehaviour, IHitable
{
    [SerializeField] private float startingHealth = 100f;

    private bool armorOn;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    private void OnEnable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged += ChangeArmorState;
        GameplayEvents.Instance.PlayerCollectedHealth += RegenerateHealth;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged -= ChangeArmorState;
        GameplayEvents.Instance.PlayerCollectedHealth -= RegenerateHealth;
    }

    private void ChangeArmorState(bool state)
    {
        armorOn = state;
    }
    private void RegenerateHealth(float hpUpAmount) 
    {
        currentHealth += hpUpAmount;
        
        if (currentHealth >= startingHealth)
            currentHealth = startingHealth;

    }
    public void GotHit(float damageTaken) 
    {
        if (armorOn) return;

        currentHealth -= damageTaken;
        GameplayEvents.Instance.PlayerGotHit?.Invoke(startingHealth, currentHealth);

        if (currentHealth <= 0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        Debug.Log("Player died");
        GameplayEvents.Instance.PlayerDied?.Invoke();
    }
}
