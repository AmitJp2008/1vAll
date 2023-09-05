using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

[RequireComponent(typeof(StarterAssetsInputs), typeof(ThirdPersonController))]
public class ThirdPersonShooterCameraController : MonoBehaviour
{
    private const float maxRaycastDistance = 999f;
    
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private float aimCharacterRotationSpeed = 20f;
    [SerializeField] private LayerMask aimColliderLayer = new LayerMask();

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Camera mainCamera;
    private Ray ray;
    private Vector2 screenCenterPoint;
    private Vector3 mouseWorldPosition;
    private Vector3 worldAimTarget;
    private Vector3 aimDirection;

    private void Awake()
    {
        mouseWorldPosition = Vector3.zero;
        worldAimTarget = Vector3.zero;
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);

        mainCamera = Camera.main;
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    void Update()
    {
        aimVirtualCamera.gameObject.SetActive(starterAssetsInputs.aim);
        thirdPersonController.SetSensitivity(starterAssetsInputs.aim ? aimSensitivity : normalSensitivity);
        
        AimRaycast();
        RotatePlayerWhileAiming(starterAssetsInputs.aim);
    }

    private void AimRaycast() 
    {
        ray = mainCamera.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRaycastDistance, aimColliderLayer)) 
        {
            mouseWorldPosition = hitInfo.point;
        }
    }

    private void RotatePlayerWhileAiming(bool aiming) 
    {
        if (!aiming) return;

        worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * aimCharacterRotationSpeed);
    }
}
