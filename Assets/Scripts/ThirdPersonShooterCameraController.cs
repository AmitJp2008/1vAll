using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ThirdPersonShooterCameraController : ThirdPersonActionsController
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;      
    private bool isAiming = false;
    
    void Update()
    {
        isAiming = StarterAssetsInputs.aim;
        aimVirtualCamera.gameObject.SetActive(isAiming);        
    }
}
