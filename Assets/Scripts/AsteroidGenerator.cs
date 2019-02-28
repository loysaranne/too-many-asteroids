using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class AsteroidGenerator : MonoBehaviour
{
    public Material mat;
    [Range(0f, 20f)]
    public float maxOffset = 4f;
    public GameObject camera;
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
        GetSpawnPoint();
        GiveRandomForce();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            CreateMeshData();
            UpdateMesh();
            CreateCollider();
        }
    }
    void CreateMeshData()
    {
        // create random vertices
        float randomVertice1_X = Random.Range(-maxOffset, -1.0f);
        float randomVertice1_Y = Random.Range(1.0f, maxOffset);

        float randomVertice2_X = Random.Range(1.0f, maxOffset);
        float randomVertice2_Y = Random.Range(1.0f, maxOffset);

        float randomVertice3_X = Random.Range(1.0f, maxOffset);
        float randomVertice3_Y = Random.Range(-maxOffset, -1.0f);

        float randomVertice4_X = Random.Range(-maxOffset, -1.0f);
        float randomVertice4_Y = Random.Range(-maxOffset, -1.0f);

        // Herranen aika saatana, what have done'd
        float higherRandom_Y;
        float higherRandom_X;
        float lowerRandom_Y;
        float lowerRandom_X;

        if (randomVertice1_Y >= randomVertice2_Y)
        {
            higherRandom_Y = randomVertice1_Y;
        }
        else higherRandom_Y = randomVertice2_Y;

        if (randomVertice2_X >= randomVertice3_X)
        {
            higherRandom_X = randomVertice2_X;
        }
        else higherRandom_X = randomVertice3_X;

        if (randomVertice3_Y <= randomVertice4_Y)
        {
            lowerRandom_Y = randomVertice3_Y;
        }
        else lowerRandom_Y = randomVertice4_Y;

        if (randomVertice1_X <= randomVertice4_X)
        {
            lowerRandom_X = randomVertice1_X;
        }
        else lowerRandom_X = randomVertice4_X;

        // Eikä tässä vielä kaikki :-)

        float randomVertice5_X = Random.Range(randomVertice1_X, randomVertice2_X);
        float randomVertice5_Y = Random.Range(higherRandom_Y, higherRandom_Y + maxOffset);

        float randomVertice6_X = Random.Range(higherRandom_X, higherRandom_X + maxOffset);
        float randomVertice6_Y = Random.Range(randomVertice2_Y, randomVertice3_Y);

        float randomVertice7_X = Random.Range(randomVertice4_X, randomVertice3_X);
        float randomVertice7_Y = Random.Range(lowerRandom_Y - maxOffset, lowerRandom_Y);

        float randomVertice8_X = Random.Range(lowerRandom_X - maxOffset, lowerRandom_X);
        float randomVertice8_Y = Random.Range(randomVertice4_Y, randomVertice1_Y);

        

        // create vertice array :---)
        vertices = new Vector3[] {  new Vector3(0,-1,0),    new Vector3(0,1,0),     new Vector3(1,0,0),
                                    new Vector3(0, -1, 0),  new Vector3(-1,0,0),    new Vector3(0,1,0),
                                    new Vector3(0,1,0),     new Vector3(-1,0,0),    new Vector3(randomVertice1_X,randomVertice1_Y, 0),
                                    new Vector3(1,0,0),     new Vector3(0,1,0),     new Vector3(randomVertice2_X, randomVertice2_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(1,0,0),     new Vector3(randomVertice3_X, randomVertice3_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(-1,0,0),    new Vector3(randomVertice4_X, randomVertice4_Y, 0),
                                    new Vector3(0,1,0),     new Vector3(randomVertice1_X, randomVertice1_Y, 0),new Vector3(randomVertice2_X, randomVertice2_Y, 0),
                                    new Vector3(1,0,0),     new Vector3(randomVertice2_X, randomVertice2_Y, 0),new Vector3(randomVertice3_X, randomVertice3_Y, 0),
                                    new Vector3(0,-1,0),    new Vector3(randomVertice3_X, randomVertice3_Y, 0),new Vector3(randomVertice4_X, randomVertice4_Y, 0),
                                    new Vector3(-1,0,0),    new Vector3(randomVertice4_X, randomVertice4_Y, 0),new Vector3(randomVertice1_X, randomVertice1_Y, 0),
                                    new Vector3(randomVertice1_X, randomVertice1_Y, 0),new Vector3(randomVertice5_X, randomVertice5_Y, 0), new Vector3(randomVertice2_X, randomVertice2_Y, 0),
                                    new Vector3(randomVertice2_X, randomVertice2_Y, 0),new Vector3(randomVertice6_X, randomVertice6_Y, 0), new Vector3(randomVertice3_X, randomVertice3_Y, 0),
                                    new Vector3(randomVertice3_X, randomVertice3_Y, 0),new Vector3(randomVertice7_X, randomVertice7_Y, 0), new Vector3(randomVertice4_X, randomVertice4_Y, 0),
                                    new Vector3(randomVertice4_X, randomVertice4_Y, 0),new Vector3(randomVertice8_X, randomVertice8_Y, 0), new Vector3(randomVertice1_X, randomVertice1_Y, 0)};
        // create triangle array
        triangles = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41 };

        // create a collider

        PolygonCollider2D col = GetComponent<PolygonCollider2D>();
        Vector2[] points = new Vector2[] {  new Vector2(randomVertice1_X, randomVertice1_Y),  new Vector2(randomVertice5_X, randomVertice5_Y),  new Vector2(randomVertice2_X, randomVertice2_Y),  new Vector2(randomVertice6_X, randomVertice6_Y),
                                            new Vector2(randomVertice3_X, randomVertice3_Y),  new Vector2(randomVertice7_X, randomVertice7_Y),  new Vector2(randomVertice4_X, randomVertice4_Y),  new Vector2(randomVertice8_X, randomVertice8_Y)};
        col.SetPath(0, points);

    }
    void UpdateMesh()
    {
        mesh.Clear();
        mesh.vertices = vertices;
        mesh.triangles = triangles;
    }
    void GetSpawnPoint()
    {
        float randomX;
        float randomY;
    }

    void GiveRandomForce()
    {

    }
    void CreateCollider()
    {
        

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(this.gameObject);

    }
}
