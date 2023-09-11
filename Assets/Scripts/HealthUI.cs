using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI health;
    [SerializeField] private Image healthBar;
    [SerializeField] private HealthHitEffect healthHitEffect;

    private void OnEnable()
    {
        GameplayEvents.Instance.PlayerGotHit += UpdateHealth;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.PlayerGotHit -= UpdateHealth;
    }

    private void UpdateHealth(float maxHealth, float currentHealth) 
    {
        if (currentHealth < 0)
            currentHealth = 0;
       
        healthBar.fillAmount = currentHealth / maxHealth;
        health.text = ((int)currentHealth).ToString();
        healthHitEffect.Playffect();
    }
}
