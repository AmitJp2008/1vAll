using UnityEngine;

[CreateAssetMenu(fileName = "New PlaneMovementData data", menuName = "GameplayData/Plane Movement Data")]
public class PlaneMovementData : ScriptableObject 
{
    public float movementSpeed;
    public float maxMovementSpeed;
}
