using UnityEngine;

[CreateAssetMenu(fileName = "New JumpMovementData data", menuName = "GameplayData/Jump Movement Data")]
public class JumpMovementData : ScriptableObject 
{
    public float jumpForce;
    public bool doubleJump; //optional
}
