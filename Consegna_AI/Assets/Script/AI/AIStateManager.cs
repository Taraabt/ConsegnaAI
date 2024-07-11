using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AIStateManager : MonoBehaviour
{


    AIBaseState currentState;
    AIWorkingState workingState=new AIWorkingState();
    AISleepingState sleepingState = new AISleepingState();
    AIThirstState thirstState = new AIThirstState();
    AIHungerState hungerState=new AIHungerState();

    public NavMeshAgent agent;
    public float chopTime;
    public bool isChopping=false;
    public GameObject home;
    public GameObject lake;
    public GameObject tree;

    private void OnEnable()
    {
        BarManager.GoWork += BackToWork;
        BarManager.ImThirst += GoDrink;
        BarManager.ImHungry += GoEat;
        TimeManager.ItsNight += GoToSleep;
        TimeManager.ItsDay += GoToWork;
    }

    private void BackToWork()
    {
        SwitchState(workingState);
    }

    private void OnDisable()
    {
        BarManager.GoWork -= BackToWork;
        BarManager.ImThirst -= GoDrink;
        BarManager.ImHungry -= GoEat;
        TimeManager.ItsNight -= GoToSleep;
        TimeManager.ItsDay -= GoToWork;
    }
    public IEnumerator ChopTree(int i)
    {
        yield return new WaitForSeconds(chopTime);
        ObjectPooler.Instance.activeTree[i].SetActive(false);
        ObjectPooler.Instance.activeTree.Remove(ObjectPooler.Instance.activeTree[i]);
        tree.SetActive(true);
        isChopping = false;
        agent.SetDestination(home.transform.position);
    }
    private void GoToSleep()
    {
        SwitchState(sleepingState);
    }

    public void GoToWork()
    {
        SwitchState(workingState);       
    }
    private void GoDrink()
    {
        SwitchState(thirstState);
    }
    private void GoEat()
    {
        SwitchState(hungerState);
    }
    private void Start()
    {
        currentState=sleepingState;
        currentState.Enter(this);
    }
    public void SwitchState(AIBaseState state)
    {
        if(TimeManager.Instance.itsNight&&state!=sleepingState)
        {
            return;
        }
        currentState = state;
        state.Enter(this);  
    }
    private void Update()
    {
        currentState.Update(this);
    }

}
