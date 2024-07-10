using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISleepingState :AIBaseState
{
    public override void Enter(AIStateManager AI)
    {

    }

    public override void Update(AIStateManager AI)
    {
        Debug.Log("Sleeping");
        AI.agent.SetDestination(AI.home.transform.position);
        if (Vector3.Distance(AI.transform.position,AI.home.transform.position)>=0.5f)
        {
            BarManager.instance.MoreHungry(0.01f);
        }
    }
}
