using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDeathState : AIState
{
    public Vector3 direction;

    public void Enter(AIAgent agent)
    {
        Debug.Log("Now Dead");
        agent.ragdollEnabler.EnableRagdoll();
        agent.weapon.DropWeapon();
        agent.weapon.enabled = false;
        agent.enabled = false;
        agent.skinnedMeshRenderer.updateWhenOffscreen = true;
    }

    public void Exit(AIAgent agent)
    {
    }

    public AIStateId GetId()
    {
        return AIStateId.Death;
    }

    public void Update(AIAgent agent)
    {
    }
}
