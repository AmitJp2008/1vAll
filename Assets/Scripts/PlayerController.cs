using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : ControllableCharacter
{
    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.PlayerMadePlaneMovementInput += Move;
        playerInput.PlayerClickedJump += Jump;
        playerInput.PlayerShoot += Shoot;
    }

    public override void Jump()
    {
    }

    public override void Move(Vector2 direction)
    {
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);

        PlayerRigidBody.velocity = (movement * MoveableData.movementSpeed * Time.deltaTime);
    }

    public override void Shoot() 
    {
    }


}
