using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
public class ThirdPersonAimAnimationController : ThirdPersonActionsController
{
    private const string aimAnimationLayerName = "Aim";
    private const float maxRaycastDistance = 999f;
    [SerializeField] private LayerMask aimColliderLayer = new LayerMask();
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private float transitionSpeed = 10f;
    [SerializeField] private float aimCharacterRotationSpeed = 20f;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private Transform debugSphere;
    private ThirdPersonController thirdPersonController;
    private int aimAnimationLayer;
    private float aimWeight;
    private bool isAiming = false;
    private Camera mainCamera;
    private Ray ray;
    private Vector3 mouseWorldPosition;
    private Vector3 aimDirection;
    private Vector3 screenCenterPoint;
    public Vector3 MouseWorldPosition => mouseWorldPosition;
    private void Awake()
    {
        aimAnimationLayer = playerAnimator.GetLayerIndex(aimAnimationLayerName);
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        mainCamera = Camera.main;
        thirdPersonController = GetComponent<ThirdPersonController>();
    }
    private void Update()
    {
        isAiming = StarterAssetsInputs.aim;
        aimWeight = StarterAssetsInputs.aim ? 1f : 0f;
        playerAnimator.SetLayerWeight(aimAnimationLayer, Mathf.Lerp(playerAnimator.GetLayerWeight(aimAnimationLayer), aimWeight, Time.deltaTime * transitionSpeed));

        thirdPersonController.SetSensitivity(isAiming ? aimSensitivity : normalSensitivity);
        thirdPersonController.SetRotationOnMove(!isAiming);
        RotatePlayerWhileAiming(isAiming);
        AimRaycast(isAiming);
        debugSphere.gameObject.SetActive(isAiming);
    }

    private void RotatePlayerWhileAiming(bool aiming)
    {
        if (!aiming) return;

        var worldAimTarget = mouseWorldPosition;
        worldAimTarget.y = transform.position.y;
        aimDirection = (worldAimTarget - transform.position).normalized;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * aimCharacterRotationSpeed);
    }
    private void AimRaycast(bool isAiming)
    {
        if (!isAiming) return;
        ray = mainCamera.ScreenPointToRay(screenCenterPoint);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxRaycastDistance, aimColliderLayer))
        {
            mouseWorldPosition = hitInfo.point;
            debugSphere.position = hitInfo.point;
        }
    }
}
