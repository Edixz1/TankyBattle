using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    public Transform exit;
    public float cooldown = 2;
    public ObjectPoolComponent projectilePool;
    

    private float elapseTime = 0;

    void Update()
    {
        elapseTime += Time.deltaTime;
    }
    public void Shoot()
    {
        if(elapseTime >= cooldown)
        {
            GameObject projectile = projectilePool.GetObject();
            projectile.transform.position = exit.position;
            projectile.transform.rotation = exit.rotation;
            projectile.SetActive(true);
            projectile.GetComponent<ProjectileComponent>().startMoving();
            elapseTime = 0;
        }
    }
}
