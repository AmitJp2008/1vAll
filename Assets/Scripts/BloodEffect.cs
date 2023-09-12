using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 1f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyDelay);        
    }
}

[CreateAssetMenu(fileName = "New armor configurations", menuName = "Gameplay/Armor Data")]
public class ArmorConfigurationData : ScriptableObject 
{
    [SerializeField] private float activationTime;
    [SerializeField] private float loadTime;

    public float ActivationTime => activationTime;
    public float LoadTime => loadTime;
}

public class ArmorUI : MonoBehaviour 
{
    [SerializeField] private Image armorFillBar;
    [SerializeField] private ArmorConfigurationData configurationData;

    private void OnEnable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged += PlayArmorUI;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged -= PlayArmorUI;

    }

    private void PlayArmorUI(bool activationState)
    {
        float duration = activationState ? configurationData.ActivationTime : configurationData.LoadTime;
        StartCoroutine(PlayArmorSequence(duration, activationState));
    }

    IEnumerator PlayArmorSequence(float fillDuration, bool activationState)
    {
        float startTime = Time.time;

        while (Time.time - startTime < fillDuration)
        {
            float elapsed = Time.time - startTime;
            float percentage = elapsed / fillDuration;

            if (activationState)
            {
                armorFillBar.fillAmount = Mathf.Clamp01(percentage);
            }
            else
            {
                armorFillBar.fillAmount = Mathf.Clamp01(1 - percentage);
            }

            yield return null;
        }

        // Fully fill or deplete the image at the end
        armorFillBar.fillAmount = activationState ? 1 : 0;
    }
}
