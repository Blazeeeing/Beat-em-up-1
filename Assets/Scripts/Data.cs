using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Data
{
    public static State currnetState = State.Idle;
}

public enum State
{
    Idle,
    Attacking,
    Moving,
    Stunned,
    Blocking,
    Crouching
}
