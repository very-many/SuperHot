using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastProjectile : Projectile
{
    public override void Launch()
    {
        base.Launch();
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            ITakeDamage[] damageTakers = hit.collider.GetComponentsInChildren<ITakeDamage>();
            //foreach (var taker in damageTakers)
            //{
            //    taker.TakeDamage(weapon, this, hit.point);
            //}
            if (damageTakers.Length > 0)
            {
                damageTakers[0].TakeDamage(weapon, this, hit.point);
            }
        }
    }
}
