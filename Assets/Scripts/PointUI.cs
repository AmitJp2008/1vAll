using UnityEngine;
using TMPro;

public class PointUI : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI points;

    private int currentPoints = 0;

    public int CurrentPoints => currentPoints;
    private void OnEnable()
    {
        GameplayEvents.Instance.EnemyDied += UpdatePoints;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.EnemyDied -= UpdatePoints;
    }


    private void UpdatePoints(EnemyBase enemy)
    {
        if (enemy != null)
        {
            currentPoints += enemy.EnemyData.KillPoints;
            points.text = currentPoints.ToString();
        }
    }
}
