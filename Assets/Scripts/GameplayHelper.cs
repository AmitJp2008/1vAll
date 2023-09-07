using UnityEngine;

public static class GameplayHelper 
{
    public static bool IsPointInsideSphere(Vector3 point, Vector3 sphereCenter, float radius)
    {
        float distance = Vector3.Distance(point, sphereCenter);
        return distance <= radius;
    }
}
