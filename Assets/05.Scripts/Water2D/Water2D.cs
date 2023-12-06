using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Water2D : MonoBehaviour
{
    public MeshFilter meshFilter;
    public int columnCount = 10;
    public float width = 2f;
    public float height = 1f;
    public float k = 0.025f;
    public float m = 1f;
    public float drag = 0.025f;
    public float spread = 0.025f;
    public float waterPower = -1.0f;
    private float power = 0.0f;
    private bool hit = false;
    public LayerMask detectLayer;
    public GameObject mainCharacterObject;
    private Vector3 detectedLayerSpeed;
    private List<WaterColumn> columns = new List<WaterColumn>();

    private void Start()
    {
        Setup();
    }

    private void Setup()
    {
        columns.Clear();
        float space = width / columnCount;
        for (int i = 0; i < columnCount + 1; i++)
        {
            columns.Add(new WaterColumn(i * space - width * 0.5f, height, k, m, drag));
        }
        
        
    }

    internal int? WorldToColumn(Vector2 position)
    {
        float space = width / columnCount;
        //float space = columnCount / width;
        int result = Mathf.RoundToInt(((position.x + transform.position.x) + width * 0.5f) / space);
        
        if (result >= columns.Count || result < 0)
            return null;
        return result;
    }



    private void Update()
    {
       
        for (int i = 0; i < columnCount; i++)
        {
            columns[i].rayVector = new Vector3(columns[i].xPos + transform.position.x, transform.position.y + height, 0.0f);
            columns[i].ray = new Ray(columns[i].rayVector, transform.up );
        }
        for (int i = 0; i < columns .Count; i++)
        {

            hit = Physics2D.Raycast(columns[i].ray.origin, columns[i].ray.direction, 0.5f , detectLayer);
            if (hit)
            {
                detectedLayerSpeed = mainCharacterObject.GetComponent<Rigidbody2D>().velocity;
                power = (detectedLayerSpeed.magnitude / 5) * waterPower;
            }
            
            if (hit && Time.frameCount % 16 == 0)
            {
                Debug.Log(power);
                columns[i].velocity = power;
                hit = false;
            }
        }
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < columns.Count; i++)
        {
            columns[i].UpdateColumn();
        }

        float[] leftDeltas = new float[columns.Count];
        float[] rightDeltas = new float[columns.Count];
        for (int i = 0; i < columns.Count; i++)
        {
            if (i > 0)
            {
                leftDeltas[i] = (columns[i].height - columns[i - 1].height) * spread;
                columns[i - 1].velocity += leftDeltas[i];
            }
            if (i < columns.Count - 1)
            {
                rightDeltas[i] = (columns[i].height - columns[i + 1].height) * spread;
                columns[i + 1].velocity += rightDeltas[i];                                   
            }
        }
        for (int i = 0; i < columns.Count; i++)
        {
            if (i > 0)
            {
                columns[i - 1].height += leftDeltas[i];
            }
            if (i < columns.Count - 1)
            {
                columns[i + 1].height += rightDeltas[i];                                   
            }
        }

        MakeMesh();
    }

    private void MakeMesh()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[columns.Count * 2];
        int v = 0;
        for (int i = 0; i < columns.Count; i++)
        {
            vertices[v] = new Vector2(columns[i].xPos, columns[i].height);
            vertices[v + 1] = new Vector2(columns[i].xPos, 0f);

            v += 2;
        }

        int[] triAngles = new int[(columns.Count - 1) * 6];
        int t = 0;
        v = 0;
        for (int i = 0; i < columns.Count - 1; i++)
        {
            triAngles[t] = v;
            triAngles[t + 1] = v + 2;
            triAngles[t + 2] = v + 1;
            triAngles[t + 3] = v + 1;
            triAngles[t + 4] = v + 2;
            triAngles[t + 5] = v + 3;

            v += 2;
            t += 6;
        }

        mesh.vertices = vertices;
        mesh.triangles = triAngles;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        mesh.Optimize();

        meshFilter.mesh = mesh;
    }
    public class WaterColumn {
        public float xPos, height, targetHeight, k, m, velocity, drag;
        public Vector3 rayVector;
        public Ray ray;

        public WaterColumn(float xPos , float targetHeight , float k , float m , float drag)
        {
            this.xPos = xPos;
            this.height = targetHeight;
            this.targetHeight = targetHeight;
            this.k = k;
            this.m = m;
            this.drag = drag;
            this.rayVector = new Vector3(xPos, height, 0.0f);
            this.ray = new Ray(rayVector, new Vector3(0.0f, 100.0f, 0.0f));
        }

      
        public void UpdateColumn()
        {
            float acc = -k / m * (height - targetHeight);
            velocity += acc;
            velocity -= drag * velocity;
            height += velocity;
        }
    }
    
}
