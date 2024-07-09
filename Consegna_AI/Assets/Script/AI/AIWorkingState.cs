using UnityEngine;

public class AIWorkingState : AIBaseState
{

    public override void Enter(AIStateManager AI)
    {
    }

    public override void Update(AIStateManager AI)
    {
        HungerBarManager.instance.MoreHungry(0.01f);
        AI.agent.SetDestination(ObjectPooler.Instance.activeTree[0].transform.position);
        if (Vector3.Distance(ObjectPooler.Instance.activeTree[0].transform.position, AI.transform.position) <= 1f&&!AI.isChopping)
        {
            AI.isChopping = true;
            AI.StartCoroutine(AI.ChopTree(0));
        }
    }
}
