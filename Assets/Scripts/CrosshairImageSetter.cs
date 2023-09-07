using System.Collections;
using System.Collections.Generic;

public class CrosshairImageSetter : WeaponImageSetter
{
    public override void SetWeaponRelatedImage(Weapon weapon)
    {
        WeaponRelatedImage.sprite = weapon.Crosshair;
    }
}