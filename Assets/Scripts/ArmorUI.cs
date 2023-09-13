using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ArmorUI : MonoBehaviour 
{
    [SerializeField] private Image armorFillBar;
    private ArmorConfigurationData configurationData;

    private void OnEnable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged += PlayArmorUI;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.ArmorActivityStateChanged -= PlayArmorUI;

    }

    public void SetArmorConfigurationData(ArmorConfigurationData armorConfigurationData) 
    {
        if (armorConfigurationData != null) 
        {
            configurationData = armorConfigurationData;
        }
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
