using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Action<Vector2> PlayerMadePlaneMovementInput;
    public Action PlayerClickedJump;
    public Action PlayerShoot;

    [SerializeField] private KeyCode jumpButton = KeyCode.Space;
    [SerializeField] private KeyCode shootingKey = KeyCode.Mouse0;
    private Vector2 inputVector;
   
    void Update()
    {
        GetMovementInput();
        GetJumpInput();
        GetShootInput();
    }
    private void GetMovementInput() 
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        inputVector = new Vector2(horizontal, vertical);
        PlayerMadePlaneMovementInput?.Invoke(inputVector);
    }
    private void GetJumpInput() 
    {
        if (Input.GetKeyDown(jumpButton))
        {
            PlayerClickedJump?.Invoke();
        }
    }

    private void GetShootInput() 
    {
        if (Input.GetKey(shootingKey))
        {
            PlayerShoot?.Invoke();
        }
    }
}
