using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class RandomMapGenerator : MonoBehaviour
{

    [SerializeField]
    public GameObject cubePrefab;

    private Vector3[] vertrices;
    private Vector3[] normals;
    private Mesh mesh;
    // Start is called before the first frame update
    void Start()
    {
        mesh = this.GetComponent<MeshFilter>().mesh;
        vertrices = mesh.vertices;
        normals = mesh.normals;
        var localScale = this.transform.localScale;
        foreach(Vector3 vertice in vertrices)
        {
            var gameobject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            gameobject.transform.parent = this.transform;
            gameobject.transform.localPosition = vertice;
            gameobject.transform.name = "" + vertice;


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
