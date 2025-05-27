using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class PhysicsDamage : MonoBehaviour, ITakeDamage
{
    private Rigidbody rigidBody;
    public Health health;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        health = GetComponent<Health>();
    }

    public void TakeDamage(Weapon weapon, Projectile projectile, Vector3 contactPoint)
    {
        if (health != null && health.enabled)
        {
            health.TakeDamage(weapon.GetDamage());
        }
        rigidBody.AddForce(projectile.transform.forward * weapon.GetDamage(), ForceMode.VelocityChange);
    }
}
