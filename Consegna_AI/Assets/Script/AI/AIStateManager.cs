using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateManager : MonoBehaviour
{
    AIBaseState currentState;
    AIWorkingState workingState=new AIWorkingState();
    AISleepingState sleepingState = new AISleepingState();
    private void OnEnable()
    {
        TimeManager.ItsNight += GoToSleep;

    }
    private void OnDisable()
    {
        TimeManager.ItsNight -= GoToSleep;
    }
    private void GoToSleep()
    {
        SwitchState(sleepingState);
    }
    private void GoDrink()
    {
        SwitchState(sleepingState);
    }
    private void GoEat()
    {
        SwitchState(sleepingState);
    }
    private void Start()
    {
        currentState=workingState;
        currentState.Enter(this);
    }
    void SwitchState(AIBaseState state)
    {
        currentState = state;
        state.Enter(this);  
    }
    private void Update()
    {
        currentState.Update(this);
    }

}
