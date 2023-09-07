using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransformGetter : MonoSingelton<PlayerTransformGetter>
{
    [SerializeField] private Transform player;

    public Transform Player => player;
}
