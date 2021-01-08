using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType { BULLET, ROCKET , MORTAR, LASER};
public class ProjectileComponent : MonoBehaviour,IPoolable
{
    public float timeToDisable = 5;
    public float speed = 50;
    public ProjectileType type;
    public ObjectPoolComponent AssociatedPool { get; set; }

    void OnEnable() => StartCoroutine(DisableOverTime());
    
    void OnDisable()  => AssociatedPool.PutObject(gameObject);

    IEnumerator DisableOverTime()
    {
        yield return new WaitForSeconds(timeToDisable);
        this.gameObject.SetActive(false);
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    public void startMoving(ProjectileType type = ProjectileType.BULLET)
    {
        switch (type)
        {
            case ProjectileType.BULLET:
                StartCoroutine(BulletPattern());
                break;
            case ProjectileType.ROCKET:
                
                break; 
            case ProjectileType.MORTAR:

                break;
            case ProjectileType.LASER:
                break;
        }
    }

    private IEnumerator BulletPattern()
    {
        while (this.gameObject.active)
        {
            yield return new WaitForEndOfFrame(); // : ) <3 bromence 
                this.transform.Translate(new Vector2(0,  speed)  *  Time.deltaTime,  Space.Self);
        }
    }
    /*
    private IEnumerator RocketPattern()
    {

    }
    private IEnumerator MortarPattern()
    {

    }
    private IEnumerator LaserPattern()
    {

    }
    */
}
