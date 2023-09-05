using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class MoveableCharacter : MonoBehaviour, IMoveable
{
    [SerializeField] private PlaneMovementData moveableData;
    private Rigidbody playerRigidBody;

    public PlaneMovementData MoveableData => moveableData;
    public Rigidbody PlayerRigidBody => playerRigidBody;
    
    private void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        ValidateMovementData();
    }

    private void FixedUpdate()
    {
        ConstrinVelocity();
    }
    private void ValidateMovementData() 
    {
        if (moveableData == null) 
        {
            Debug.LogError("ValidateMovementData: moveableData is null - Error");
        }
    }

    private void ConstrinVelocity()
    {
        if (playerRigidBody == null) 
        {
            Debug.LogError("ConstrinVelocity: rigidbody is null - error");
            return;
        }

        if (playerRigidBody.velocity.magnitude > moveableData.maxMovementSpeed)
        {
            playerRigidBody.velocity = playerRigidBody.velocity.normalized * moveableData.maxMovementSpeed;
        }
    }

    public abstract void Move(Vector2 direction);
}
