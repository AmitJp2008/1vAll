using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : ThirdPersonActionsController
{
    [SerializeField] private Player player;
    [SerializeField] private ArmorConfigurationData armorConfigurationData;
    [SerializeField] ArmorUI armorUI;

    private bool armorReadyToUse = true;
    private void Start()
    {
        SetArmorUi();
    }
    private void Update()
    {
        if (StarterAssetsInputs.armor) 
        {
            StarterAssetsInputs.armor = false;
            if (armorReadyToUse) 
            {
                GameplayEvents.Instance.ArmorActivityStateChanged?.Invoke(true);
                StartCoroutine(EnableArmor());
                armorReadyToUse = false;
            }
        }
    }

    private void SetArmorUi()
    {
        if (armorConfigurationData == null) return;
        armorUI.SetArmorConfigurationData(armorConfigurationData);
    }

    private IEnumerator EnableArmor()
    {
        yield return new WaitForSeconds(armorConfigurationData.ActivationTime);
        GameplayEvents.Instance.ArmorActivityStateChanged?.Invoke(false);
        yield return new WaitForSeconds(armorConfigurationData.LoadTime);
        armorReadyToUse = true;
    }
}
