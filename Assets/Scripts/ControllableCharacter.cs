using UnityEngine;

public abstract class ControllableCharacter : MoveableCharacter, IJump, IShooter
{
    public JumpMovementData jumpData;
    private void OnEnable()
    {
        ValidateJumpData();
    }

    private void ValidateJumpData() 
    {
        if (jumpData == null)
        {
            Debug.LogError("ValidateJumpData: jumpData is null - Error");
        }
    }
    public abstract void Jump();
    public abstract void Shoot();
}
