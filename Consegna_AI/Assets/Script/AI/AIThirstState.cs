using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThirstState : AIBaseState
{
    public override void Enter(AIStateManager AI)
    {
        AI.agent.SetDestination(AI.lake.transform.position);
    }

    public override void Update(AIStateManager AI)
    {
        Debug.Log("Thirst");
        Debug.Log(Vector3.Distance(AI.transform.position, AI.lake.transform.position));
        if(Vector3.Distance(AI.transform.position,AI.lake.transform.position)<=7)
        {
            BarManager.instance.LessHungry(0.02f);
        }
        else
        {
            BarManager.instance.MoreHungry(0.01f);
        }
    }
}
