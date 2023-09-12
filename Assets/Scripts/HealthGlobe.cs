using UnityEngine;

public class HealthGlobe : MonoBehaviour 
{
    private float healAmount = 0;
    public void SetHealthGlobe(float healAmount) 
    {
        this.healAmount = healAmount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") 
        {
            GameplayEvents.Instance.PlayerCollectedHealth?.Invoke(healAmount);
            Destroy(gameObject);
        }
    }
}
