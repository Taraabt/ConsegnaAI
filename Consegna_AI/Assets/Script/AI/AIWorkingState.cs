using UnityEngine;

public class AIWorkingState : AIBaseState
{

    public override void Enter(AIStateManager AI)
    {
        AI.agent.SetDestination(AI.home.transform.position);
    }

    public override void Update(AIStateManager AI)
    {
        Debug.Log("Work");
        BarManager.instance.MoreThirst(0.007f);
        BarManager.instance.MoreHunger(0.005f);
        if (Vector3.Distance(AI.agent.transform.position,AI.home.transform.position)<=1)
        {
            AI.tree.SetActive(false);
            AI.agent.SetDestination(ObjectPooler.Instance.activeTree[0].transform.position);
        }
        if (Vector3.Distance(ObjectPooler.Instance.activeTree[0].transform.position, AI.transform.position) <= 1f&&!AI.isChopping)
        {
            AI.isChopping = true;
            AI.StartCoroutine(AI.ChopTree(0));
        }
    }
}
