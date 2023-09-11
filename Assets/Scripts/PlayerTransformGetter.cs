using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformGetter : MonoSingleton<PlayerTransformGetter>
{
    [SerializeField] private Transform player;

    public Transform Player => player;
}
