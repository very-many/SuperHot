using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Pistol : Weapon
{
    [SerializeField] private Projectile bulletPrefab;

    protected override void StartShooting(ActivateEventArgs interactor)
    {
        //base.StartShooting(interactor);
        Shoot();
    }

    public override void Shoot()
    {
        base.Shoot();
        Projectile projectileInstance = Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        projectileInstance.Init(this);
        projectileInstance.Launch();
    }
}
