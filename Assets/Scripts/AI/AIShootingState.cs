using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShootingState : AIState
{
    public void Enter(AIAgent agent)
    {
        Debug.Log("Now Shooting");
    }

    public void Exit(AIAgent agent)
    {
        //throw new System.NotImplementedException();
    }

    public AIStateId GetId()
    {
        return AIStateId.Shooting;
    }

    public void Update(AIAgent agent)
    {
        agent.weapon.ShootWeapon();
    }
}
