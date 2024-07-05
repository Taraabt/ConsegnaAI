using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBaseState 
{
    public abstract void Enter(AIStateManager AI);
    public abstract void Update(AIStateManager AI);
}
