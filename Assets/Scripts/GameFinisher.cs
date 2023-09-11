using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinisher : MonoBehaviour
{
    private void OnEnable()
    {
        GameplayEvents.Instance.PlayerDied += FinishGame;
    }
    private void OnDisable()
    {
        GameplayEvents.Instance.PlayerDied -= FinishGame;        
    }

    private void FinishGame() 
    {
        Debug.Log("FinishGame: Game over - stop game");
        Time.timeScale = 0f;
    }
}
