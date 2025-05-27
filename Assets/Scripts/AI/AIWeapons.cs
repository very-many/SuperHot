using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeapons : MonoBehaviour
{
    public GameObject weapon;
    public float flightTime = 2f;
    public float flightAngle = 45f;
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void DropWeapon()
    {
        weapon.transform.parent = null;
        Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        weaponRb.velocity = Vector3.zero;
        weapon.transform.position += weapon.transform.up * 0.5f;
        weaponRb.velocity = BallisticVelocityVector(weapon.transform.position, playerTransform.position, 45);
        weaponRb.angularVelocity = Vector3.zero;
    }

    private Vector3 BallisticVelocityVector(Vector3 source, Vector3 target, float angle )
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

    public void ShootWeapon()
    {
        if (!weapon) return;

        Weapon weaponScript = weapon.GetComponent<Weapon>();
        if (!weaponScript) return;

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        Transform bulletSpawn = weaponScript.bulletSpawn.transform;
        Vector3 directionToPlayer = playerTransform.position - bulletSpawn.position;

        bulletSpawn.rotation = Quaternion.LookRotation(directionToPlayer);

        weaponScript.Shoot();
    }
}
