using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileComponent : MonoBehaviour
{
    public ObjectPoolComponent AssociatedPool { get; set; }
    private void Awake()
    {   
        AssociatedPool.PutObject(gameObject);
    }
}
