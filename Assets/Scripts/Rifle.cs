using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rifle : Weapon
{
    [SerializeField] private float fireRate;
    [SerializeField] bool isRaycast = false;
    [SerializeField] private Projectile projectile;

    private WaitForSeconds wait;

    protected override void Awake()
    {
        base.Awake();
        if (isRaycast)
        {
            projectile = GetComponentInChildren<Projectile>();
        }
    }

    private void Start()
    {
        wait = new WaitForSeconds(1/fireRate);
        if (isRaycast)
        {
            projectile.Init(this);
        }
    }

    protected override void StartShooting(ActivateEventArgs interactor)
    {
        base.StartShooting(interactor);
        StartCoroutine(ShootingCO());
    }

    private IEnumerator ShootingCO()
    {
        while (true)
        {
            Shoot();
            yield return wait;
        }
    }

    public override void Shoot()
    {
        base.Shoot();
        if (isRaycast)
        {
            projectile.Launch();
        }
        else
        {
            Projectile projectileInstance = Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
            projectileInstance.Init(this);
            projectileInstance.Launch();
        }
    }

    protected override void StopShooting(DeactivateEventArgs interactor)
    {
        base.StopShooting(interactor);
        StopAllCoroutines();
    }
}
