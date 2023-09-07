using UnityEngine;
using UnityEngine.UI;

public abstract class WeaponImageSetter : MonoBehaviour, IWeaponImageSetter
{
    [SerializeField] private Image weaponRelatedImage;

    public Image WeaponRelatedImage => weaponRelatedImage;

    private void OnEnable()
    {
        GameplayEvents.Instance.PlayerChangedWeapon += SetWeaponRelatedImage;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.PlayerChangedWeapon -= SetWeaponRelatedImage;
    }
    public abstract void SetWeaponRelatedImage(Weapon weapon);
}
