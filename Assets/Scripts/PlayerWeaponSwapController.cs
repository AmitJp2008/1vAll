using StarterAssets;
using UnityEngine;

public class PlayerWeaponSwapController : ThirdPersonActionsController
{
    [SerializeField] private Weapon[] playerWeapons;

    private void Start()
    {
        ChangeWeapon(0);
    }
    private void Update()
    {
        if (StarterAssetsInputs.weapon_1) 
        {
            ChangeWeapon(0);
            StarterAssetsInputs.weapon_2 = false;
        }
        if (StarterAssetsInputs.weapon_2)
        {
            ChangeWeapon(1);
            StarterAssetsInputs.weapon_1 = false;
        }
    }

    private void ChangeWeapon(int weaponSlot) 
    {
        if (playerWeapons != null && playerWeapons[weaponSlot] != null) 
        {
            GamplayEvents.Instance.PlayerChangedWeapon?.Invoke(playerWeapons[weaponSlot]);
            Debug.Log($"ChangeWeapon: player swap to {playerWeapons[weaponSlot].Name}");
        }
    }
}
