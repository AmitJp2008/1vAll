using StarterAssets;
using UnityEngine;

public class ThirdPersonShootingController : ThirdPersonActionsController
{
    [SerializeField] private ThirdPersonAimAnimationController thirdPersonAimAnimationController;
    [SerializeField] private Transform bulletSpawnPosition;
    private Weapon chosenWeapon;

    private float shootTimer = 0f;
    private float shootCooldown => 1f / (chosenWeapon?.ShootFrequency ?? 1f); // Calculate cooldown based on frequency

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
        // Update the shooting timer
        shootTimer += Time.deltaTime;

        if (chosenWeapon != null && StarterAssetsInputs.aim)
        {
            if (shootTimer >= shootCooldown && StarterAssetsInputs.shoot)
            {
                Shoot();
                shootTimer = 0f;  // Reset the timer after shooting
            }
        }
    }

    private void SetCurrentChosenWeapon(Weapon chosenWeapon)
    {
        ResetTimers();
        this.chosenWeapon = chosenWeapon;
    }
    private void ResetTimers() 
    {
        shootTimer = 0f;  // Reset the timer after shooting
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
        AudioSource.PlayClipAtPoint(chosenWeapon.ShotSound, transform.position, 1);
    }
}

