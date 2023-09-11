using System;
using UnityEngine;
/// <summary>
/// This class contains all Gameplay events and works as an event bus
/// </summary>
[DefaultExecutionOrder(-50)]
public class GameplayEvents : MonoSingleton<GameplayEvents>
{
    public Action<Weapon> PlayerChangedWeapon;
    public Action<GameObject, float> TargetGotHit;
    public Action<EnemyBase> EnemyDied;
    public Action<GameState> GameStateChanged;
    public Action<int> WaveCreated;
    public Action<bool> ArmorActivityStateChanged;
    public Action PlayerDied;
    public Action<float, float> PlayerGotHit;
    public Action<float> PlayerCollectedHealth;
}