using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;

public class DumbEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private RagdollEnabler ragdoll;
    public Transform playerTarget;
    public Transform playerHead;
    [SerializeField] private float stopDistance = 5;
    public Weapon weapon;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        ragdoll = GetComponent<RagdollEnabler>();
        weapon.GetComponent<XRGrabInteractable>().enabled = false;
    }

    void Update()
    {
        agent.SetDestination(playerTarget.position);
        animator.SetFloat("Speed", agent.speed);

        float distance = Vector3.Distance(playerTarget.position, transform.position);
        if (distance < stopDistance)
        {
            agent.isStopped = true;
            animator.SetBool("Shoot", true);
        }
        else
        {
            animator.SetBool("Shoot", false);
            agent.isStopped = false;
        }
    }

    public void DropWeapon()
    {
        weapon.transform.parent = null;
        weapon.GetComponent<XRGrabInteractable>().enabled = true;
        weapon.bulletSpawn.transform.localRotation = Quaternion.identity;
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        weaponRb.velocity = Vector3.zero;
        weapon.transform.position += weapon.transform.up * 0.5f;
        weaponRb.velocity = BallisticVelocityVector(weapon.transform.position, playerTarget.position, 45);
        weaponRb.angularVelocity = Vector3.zero;
    }

    private Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle)
    {
        Vector3 direction = target - source;
        float h = direction.y;
        direction.y = 0;
        float distance = direction.magnitude;
        float a = angle * Mathf.Deg2Rad;
        direction.y = distance * Mathf.Tan(a);
        distance += h / Mathf.Tan(a);

        //calc velocity
        float velocity = Mathf.Sqrt(distance * Physics.gravity.magnitude / Mathf.Sin(2 * a));
        return velocity * direction.normalized;
    }

    public void ShootEnemy()
    {
        Vector3 playerHeadPosition = playerHead.position - Random.Range(0, 0.4f) * Vector3.up;

        weapon.bulletSpawn.forward = (playerHeadPosition - weapon.bulletSpawn.position).normalized;

        weapon.Shoot();
    }

    public void Die()
    {
        ragdoll.EnableRagdoll();
        DropWeapon();
        agent.enabled = false;
        this.enabled = false;
    }

}
