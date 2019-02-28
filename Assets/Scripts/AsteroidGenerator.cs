using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AsteroidGenerator : MonoBehaviour
{
    public Material mat;
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    void Awake()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        GetComponent<MeshRenderer>().material = mat;
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateMeshData();
        UpdateMesh();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CreateMeshData();
            UpdateMesh();
        }
    }
    void CreateMeshData()
    {
        // create random vertices
        float randomVertice1_X = Random.Range(-4.0f, -1.0f);
        float randomVertice1_Y = Random.Range(1.0f, 4.0f);

        float randomVertice2_X = Random.Range(1.0f, 4.0f);
        float randomVertice2_Y = Random.Range(1.0f, 4.0f);

        float randomVertice3_X = Random.Range(1.0f, 4.0f);
        float randomVertice3_Y = Random.Range(-4.0f, -1.0f);

        float randomVertice4_X = Random.Range(-4.0f, -1.0f);
        float randomVertice4_Y = Random.Range(-4.0f, -1.0f);

        // create vertice array
        vertices = new Vector3[] {  new Vector3(0,-1,0),    new Vector3(0,1,0),     new Vector3(1,0,0),
                                    new Vector3(0, -1, 0),  new Vector3(-1,0,0),    new Vector3(0,1,0),
                                    new Vector3(0,1,0),     new Vector3(-1,0,0),    new Vector3(randomVertice1_X,randomVertice1_Y, 0),
                                    new Vector3(1,0,0),     new Vector3(0,1,0),     new Vector3(randomVertice2_X, randomVertice2_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(1,0,0),     new Vector3(randomVertice3_X, randomVertice3_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(-1,0,0),    new Vector3(randomVertice4_X, randomVertice4_Y, 0),
                                    new Vector3(0,1,0),     new Vector3(randomVertice1_X, randomVertice1_Y, 0),new Vector3(randomVertice2_X, randomVertice2_Y, 0),
                                    new Vector3(1,0,0),     new Vector3(randomVertice2_X, randomVertice2_Y, 0),new Vector3(randomVertice3_X, randomVertice3_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(randomVertice3_X, randomVertice3_Y, 0),new Vector3(randomVertice4_X, randomVertice4_Y, 0),
                                    new Vector3(-1,0,0),    new Vector3(randomVertice4_X, randomVertice4_Y, 0),new Vector3(randomVertice1_X, randomVertice1_Y, 0)};
        // create triangle array
        triangles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29 };

    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
}
