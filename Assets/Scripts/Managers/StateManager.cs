using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    private State currentState;


    public void SetState(State state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        currentState.OnStateEnter();
    }

    private void Update()
    {
        if (currentState != null) currentState.UpdateState();
    }
}
