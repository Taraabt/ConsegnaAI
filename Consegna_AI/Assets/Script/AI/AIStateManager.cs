using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{


    AIBaseState currentState;
    AIWorkingState workingState=new AIWorkingState();
    AISleepingState sleepingState = new AISleepingState();

    public NavMeshAgent agent;
    public float chopTime;
    public bool isChopping=false;
    public GameObject home;

    private void OnEnable()
    {
        TimeManager.ItsNight += GoToSleep;
        TimeManager.ItsDay += GoToWork;
    }
    private void OnDisable()
    {
        TimeManager.ItsNight -= GoToSleep;
        TimeManager.ItsDay -= GoToWork;
    }
    public IEnumerator ChopTree(int i)
    {
        yield return new WaitForSeconds(chopTime);
        ObjectPooler.Instance.activeTree[i].SetActive(false);
        ObjectPooler.Instance.activeTree.Remove(ObjectPooler.Instance.activeTree[i]);
        isChopping = false;
    }
    private void GoToSleep()
    {
        SwitchState(sleepingState);
    }

    private void GoToWork()
    {
        SwitchState(workingState);
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
        currentState=sleepingState;
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
