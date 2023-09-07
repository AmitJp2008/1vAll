using StarterAssets;
using UnityEngine;

public class PlayerWeaponSwapController : ThirdPersonActionsController
{
    [SerializeField] private Weapon[] playerWeapons;
    [SerializeField] private Transform weaponSpawnPosition;

    private void Start()
    {
        ChangeWeapon(0);
    }
    private void Update()
    {
        if (StarterAssetsInputs.weapon_1) 
        {
            ChangeWeapon(0);
        }
        if (StarterAssetsInputs.weapon_2)
        {
            ChangeWeapon(1);
        }
    }

    private void ChangeWeapon(int weaponSlot) 
    {
        if (playerWeapons != null && playerWeapons[weaponSlot] != null) 
        {
            SpawnWeaponModel(playerWeapons[weaponSlot].WeaponModel);
            GameplayEvents.Instance.PlayerChangedWeapon?.Invoke(playerWeapons[weaponSlot]);
            Debug.Log($"ChangeWeapon: player swap to {playerWeapons[weaponSlot].Name}");
            ResetWeaponChangeIndicators();
        }
    }
    private void ResetWeaponChangeIndicators()
    {
        StarterAssetsInputs.weapon_2 = false;
        StarterAssetsInputs.weapon_1 = false;
    }
    private void SpawnWeaponModel(GameObject weaponModel) 
    {
        if (weaponModel == null) return;

        bool weaponExist = false;

        foreach (Transform child in weaponSpawnPosition)
        {
            bool objectExist = child.gameObject.name.ToLower() == weaponModel.name.ToLower();
            child.gameObject.SetActive(objectExist);
            if (child.gameObject.name.ToLower() == weaponModel.name.ToLower())
            {
                weaponExist = true;
            }
        }
        if (!weaponExist) 
        {
            var weaponObj = Instantiate(weaponModel, weaponSpawnPosition);
            weaponObj.name = weaponModel.name;
        }
    }
}
