using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI enemiesAmount;

    private int amountOfEnemies = 0;

    private void OnEnable()
    {
        GameplayEvents.Instance.WaveCreated += UpdateAmountOfEnemies;
        GameplayEvents.Instance.EnemyDied += DecreaseEnemy;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.WaveCreated += UpdateAmountOfEnemies;
        GameplayEvents.Instance.EnemyDied += DecreaseEnemy;
    }

    private void DecreaseEnemy(EnemyBase _)
    {
        amountOfEnemies--;
        SetEnemyText(amountOfEnemies);
    }

    private void UpdateAmountOfEnemies(int amountOfEnemies)
    {
        this.amountOfEnemies = amountOfEnemies;
        SetEnemyText(amountOfEnemies);
    }

    private void SetEnemyText(int amountOfEnemies) 
    {
        enemiesAmount.text = amountOfEnemies.ToString();
    }
}
