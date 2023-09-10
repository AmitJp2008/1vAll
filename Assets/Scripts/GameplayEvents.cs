using System;
using UnityEngine;
/// <summary>
/// This class contains all Gameplay events and works as an event bus
/// </summary>
[DefaultExecutionOrder(-50)]
public class GameplayEvents : MonoSingelton<GameplayEvents>
{
    public Action<Weapon> PlayerChangedWeapon;
    public Action<GameObject, float> BulletHitEnemy;
    public Action<GameObject> EnemyDied;
}