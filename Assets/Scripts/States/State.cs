using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public abstract void OnStateEnter();
    public abstract void UpdateState();
    public abstract void OnStateExit();
}
