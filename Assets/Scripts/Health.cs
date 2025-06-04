using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    [SerializeField] private RagdollEnabler ragdollEnabler;

    private SkinnedMeshRenderer skinnedMeshRenderer;


    [SerializeField] private float blinkIntensity;
    [SerializeField] private float blinkDuration;
    private float blinkTimer;

    private AIAgent agent;

    private DumbEnemy tempEnemy;

    void Start()
    {
        tempEnemy = GetComponent<DumbEnemy>();
        //agent = GetComponent<AIAgent>();
        currentHealth = maxHealth;
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

        var rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidbodies)
        {
            PhysicsDamage bodyPart = rigidbody.gameObject.AddComponent<PhysicsDamage>();
            bodyPart.health = this;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0f)
        {
            Die();
            this.enabled = false;
        }

        blinkTimer = blinkDuration;
    }

    private void Die()
    {
        //agent.stateMachine.ChangeState(AIStateId.Death); //THIS IS BETTER
        tempEnemy.Die();
    }

    private void Update()
    {
        TakeDamage(0);
        //blinkTimer -= Time.deltaTime;
        //float lerp = Mathf.Clamp01(blinkDuration / blinkTimer);
        //float intensity = (lerp * blinkIntensity);
        //if (blinkTimer > 0f)
        //{
        //    Debug.Log(intensity);
        //}
        ////skinnedMeshRenderer.material.EnableKeyword("_EMISSION");
        //skinnedMeshRenderer.material.SetColor("_EmissionColor", Color.white * intensity);
    }
}
