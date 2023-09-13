using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorController : ThirdPersonActionsController
{
    [SerializeField] private ArmorConfigurationData armorConfigurationData;
    [SerializeField] ArmorUI armorUI;

    private bool armorUiExist = false;
    private bool armorReadyToUse = true;
    private void Start()
    {
        armorUiExist = SetArmorUi();
    }
    private void Update()
    {
        if (!armorUiExist) return;

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

    private bool SetArmorUi()
    {
        if (armorConfigurationData == null || armorUI == null) return false;
        armorUI.SetArmorConfigurationData(armorConfigurationData);
        return true;
    }

    private IEnumerator EnableArmor()
    {
        yield return new WaitForSeconds(armorConfigurationData.ActivationTime);
        GameplayEvents.Instance.ArmorActivityStateChanged?.Invoke(false);
        yield return new WaitForSeconds(armorConfigurationData.LoadTime);
        armorReadyToUse = true;
    }
}
