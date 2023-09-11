using UnityEngine;

public class BulletEnemy : BulletControllerBase 
{
    public override void OnBulletCollision(Collider collider) 
    {
        if (collider.gameObject.tag == EffectiveTag)
        {
            GameplayEvents.Instance.TargetGotHit?.Invoke(collider.gameObject, BulletDamage);
            Destroy(gameObject);
        }
    }
}
