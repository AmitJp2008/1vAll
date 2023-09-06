using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool aim;
		public bool shoot;
		public bool weapon_1;
		public bool weapon_2;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}
		public void OnShoot(InputValue value)
		{
			ShootInput(value.isPressed);
		}
		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }
		public void OnChangeWeapon_1(InputValue value) 
		{
			Debug.Log("1 pressed");
			ChangeWeaponInput_1(value.isPressed);
		}
		public void OnChangeWeapon_2(InputValue value) 
		{
			Debug.Log("2 pressed");
			ChangeWeaponInput_2(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}
		public void ShootInput(bool newShootState)
		{
			shoot = newShootState;
		}
		public void SprintInput(bool newSprintState)
		{		
			sprint = newSprintState;
		}
		public void AimInput(bool newAimState) 
		{
			aim = newAimState;
		}
		public void ChangeWeaponInput_1(bool chosenWeaponState) 
		{
			weapon_1 = chosenWeaponState;
		}
		public void ChangeWeaponInput_2(bool chosenWeaponState)
		{
			weapon_2 = chosenWeaponState;
		}
		
		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}	
}
