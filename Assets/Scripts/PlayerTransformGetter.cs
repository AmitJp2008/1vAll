using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformGetter : MonoSingleton<PlayerTransformGetter>
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerAimPoint;

    public Transform Player => player;
    public Transform PlayerAimPoint => playerAimPoint;
}
