using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageApplyer : MonoBehaviour
{
    private void OnEnable()
    {
        GameplayEvents.Instance.TargetGotHit += DamageTarget;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.TargetGotHit -= DamageTarget;
    }

    private void DamageTarget(GameObject targetObj, float damageToApply)
    {
        if (targetObj == null) return;

        IHitable hitable = targetObj.GetComponent<IHitable>();
        if(hitable == null) hitable = targetObj.transform.parent.GetComponent<IHitable>();

        if (hitable != null)
        {
            hitable.GotHit(damageToApply);
        }
        else 
        {
            Debug.Log($"DamageTarget: No IHitable on {targetObj} - error");
        }
    }
}
