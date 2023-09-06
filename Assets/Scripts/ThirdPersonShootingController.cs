using StarterAssets;
using UnityEngine;

public class ThirdPersonShootingController : ThirdPersonActionsController 
{
    [SerializeField] private ThirdPersonAimAnimationController thirdPersonAimAnimationController;
    [SerializeField] private Transform bulletSpawnPosition;
    private Weapon chosenWeapon;

    private void OnEnable()
    {
        GamplayEvents.Instance.PlayerChangedWeapon += SetCurrentChosenWeapon;
    }
    private void OnDisable()
    {
        GamplayEvents.Instance.PlayerChangedWeapon -= SetCurrentChosenWeapon;
    }
    private void Update()
    {
        if (chosenWeapon != null && StarterAssetsInputs.aim) 
        {
            if (!StarterAssetsInputs.shoot) return;

            Shoot();
            StarterAssetsInputs.shoot = chosenWeapon.ShootFrequency > 0;
        }
    }

    private void SetCurrentChosenWeapon(Weapon chosenWeapon) 
    {
        this.chosenWeapon = chosenWeapon;
    }
    private void Shoot() 
    {
        if (chosenWeapon == null) return;

        Vector3 aimDir = (thirdPersonAimAnimationController.MouseWorldPosition - bulletSpawnPosition.position).normalized;
        Instantiate(chosenWeapon.Bullet, bulletSpawnPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        PlayShotSound();
    }

    private void PlayShotSound()
    {
        if (chosenWeapon.ShotSound == null) return;
        AudioSource.PlayClipAtPoint(chosenWeapon.ShotSound, transform.TransformPoint(transform.position), 1);
    }
}
