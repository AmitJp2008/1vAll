using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    [SerializeField] private float destroyDelay = 1f;

    private void OnEnable()
    {
        Destroy(gameObject, destroyDelay);        
    }
}
