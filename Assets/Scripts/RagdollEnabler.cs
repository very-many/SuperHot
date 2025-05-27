using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollEnabler : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform ragdollRoot;
    [SerializeField]
    private bool startRagdoll = false;
    // Only public for Ragdoll Runtime GUI for explosive force
    public Rigidbody[] rigidBodies;
    private CharacterJoint[] joints;
    private Collider[] colliders;

    private void Awake()
    {
        rigidBodies = ragdollRoot.GetComponentsInChildren<Rigidbody>();
        joints = ragdollRoot.GetComponentsInChildren<CharacterJoint>();
        colliders = ragdollRoot.GetComponentsInChildren<Collider>();

        if (startRagdoll)
        {
            EnableRagdoll();
        }
        else
        {
            EnableAnimator();
        }
    }

    public void EnableRagdoll()
    {
        animator.enabled = false;
        //foreach (CharacterJoint joint in joints)
        //{
        //    joint.enableCollision = true;
        //}
        //foreach (Collider collider in colliders)
        //{
        //    collider.enabled = true;
        //}
        //foreach (Rigidbody rigidbody in rigidBodies)
        //{
        //    rigidbody.velocity = Vector3.zero;
        //    rigidbody.detectCollisions = true;
        //    rigidbody.useGravity = true;
        //}
        foreach (Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.isKinematic = false;
        }
    }

    public void EnableAnimator()
    {
        animator.enabled = true;
        //foreach (CharacterJoint joint in joints)
        //{
        //    joint.enableCollision = false;
        //}
        //foreach (Collider collider in colliders)
        //{
        //    collider.enabled = false;
        //}
        //foreach (Rigidbody rigidbody in rigidBodies)
        //{
        //    rigidbody.detectCollisions = false;
        //    rigidbody.useGravity = false;
        //}
        foreach (Rigidbody rigidbody in rigidBodies)
        {
            rigidbody.isKinematic = true;
        }
    }
}
