using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ChunkRenderer : MonoBehaviour
{
    private const int ChunkWidth = 10;
    private const int WidthHeight = 128;
    public int [,,] blocks = new int [ChunkWidth, ChunkWidth, WidthHeight];

    private List<Vector3> verticies = new List<Vector3>();
    private List<int> triangles = new List<int>();
    
    void Start()
    {
        Mesh chunkMesh = new Mesh();
        
        verticies.Add(new Vector3(0,0,0));
        verticies.Add(new Vector3(0,1,0));
        verticies.Add(new Vector3(0,0,1));
        
        
        GetComponent<MeshFilter>().mesh = chunkMesh;

    }

    void Update()
    {
        
    }
}
