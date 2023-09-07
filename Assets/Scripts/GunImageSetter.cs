public class GunImageSetter : WeaponImageSetter
{
    public override void SetWeaponRelatedImage(Weapon weapon)
    {
        WeaponRelatedImage.sprite = weapon.WeaponImage;
    }
}