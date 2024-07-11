using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHungerState : AIBaseState
{
    public override void Enter(AIStateManager AI)
    {
    }

    public override void Update(AIStateManager AI)
    {
        Debug.Log("Hungry");
        if (ObjectPooler.Instance.pooledFood[0].activeInHierarchy)
        {
            AI.agent.SetDestination(ObjectPooler.Instance.pooledFood[0].transform.position);
            if (Vector3.Distance(AI.agent.transform.position, ObjectPooler.Instance.pooledFood[0].transform.position)<=1)
            {
                ObjectPooler.Instance.pooledFood[0].SetActive(false);
                ObjectPooler.Instance.pooledFood.Remove(ObjectPooler.Instance.pooledFood[0]);
                BarManager.instance.LessHunger(50f);
                AI.GoToWork();
            }
        }
    }
}
