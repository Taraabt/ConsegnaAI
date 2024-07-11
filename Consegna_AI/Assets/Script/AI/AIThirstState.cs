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
        if(Vector3.Distance(AI.transform.position,AI.lake.transform.position)<=6)
        {
            BarManager.instance.LessThirst(0.05f);
        }
    }
}
