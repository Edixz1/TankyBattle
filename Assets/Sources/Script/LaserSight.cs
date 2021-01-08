using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaserSight : MonoBehaviour
{
    LineRenderer line;
    GameObject Point1;
    GameObject Point2;
    GameObject Point3;
    public float MaxLenghtOfLaser = 50;
    private void Awake()
    {
        line = this.GetComponent<LineRenderer>();
        Point1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Point2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Point3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        Point1.GetComponent<Collider>().enabled = false;
        Point2.GetComponent<Collider>().enabled = false;
        Point3.GetComponent<Collider>().enabled = false;

    


    }

    private void Update()
    {
        
        Vector3 vector = this.transform.position;
        Point1.transform.position = vector;
        Point2.transform.position = transform.TransformPoint(line.GetPosition(1) + Vector3.up * MaxLenghtOfLaser);
        Point3.transform.position = transform.TransformPoint(line.GetPosition(0));
        RaycastHit2D[] raycastHits = new RaycastHit2D[1];
        ContactFilter2D contactFilter2D = new ContactFilter2D();
        
        if (Physics2D.Linecast(vector, Point2.transform.position,contactFilter2D,raycastHits) != 0)
        {
            
            line.SetPosition(0, (line.GetPosition(1) + Vector3.up * raycastHits[0].distance)*2);

        }else
            line.SetPosition(0, line.GetPosition(1) + Vector3.up * MaxLenghtOfLaser);
    }
}
