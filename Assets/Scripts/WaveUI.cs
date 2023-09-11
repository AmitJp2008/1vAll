using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wave;

    private int currentWaveCounter;
    private void OnEnable()
    {
        GameplayEvents.Instance.WaveCreated += UpdateWave;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.WaveCreated -= UpdateWave;

    }

    private void UpdateWave(int _) 
    {
        currentWaveCounter++;
        wave.text = "Wave: " + currentWaveCounter.ToString();
    }
}
