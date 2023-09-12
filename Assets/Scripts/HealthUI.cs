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

    private float lastHealthAmount;
    private void OnEnable()
    {
        GameplayEvents.Instance.PlayerGotHit += UpdateHealth;
        GameplayEvents.Instance.PlayerGotHit += PlayerHit;
        GameplayEvents.Instance.PlayerHealed += UpdateHealth;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.PlayerGotHit -= UpdateHealth;
        GameplayEvents.Instance.PlayerGotHit -= PlayerHit;
        GameplayEvents.Instance.PlayerHealed -= UpdateHealth;
    }

    private void PlayerHit(float _, float __) 
    {
        healthHitEffect.Playffect();
    }

    private void UpdateHealth(float maxHealth, float currentHealth) 
    {
        if (currentHealth < 0)
            currentHealth = 0;
       
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.fillAmount = currentHealth / maxHealth;
        health.text = ((int)currentHealth).ToString();
    }
}
