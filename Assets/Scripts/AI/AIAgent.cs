using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public AIStateMachine stateMachine;
    public AIStateId initialState;
    public NavMeshAgent navMeshAgent;
    public AIAgentConfig config;
    public RagdollEnabler ragdollEnabler;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public Transform playerTransform;
    public AIWeapons weapon;
    public AISensor sensor;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        ragdollEnabler = GetComponent<RagdollEnabler>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        weapon = GetComponent<AIWeapons>();
        sensor = GetComponent<AISensor>();

        stateMachine = new AIStateMachine(this);
        stateMachine.RegisterState(new AIChasePlayerState());
        stateMachine.RegisterState(new AIDeathState());
        stateMachine.RegisterState(new AIIdleState());
        stateMachine.RegisterState(new AIShootingState());
        stateMachine.ChangeState(initialState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
