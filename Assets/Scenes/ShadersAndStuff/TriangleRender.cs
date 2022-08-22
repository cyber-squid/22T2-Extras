using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleRender : MonoBehaviour
{

    MeshRenderer meshRenderer;
    MeshFilter meshFilter;

    [SerializeField] Texture2D heightmap;

    [SerializeField] int RectCountOnX = 5;
    [SerializeField] int RectCountOnZ = 5;  // number of rectangles each row.
    [SerializeField] float heightMultiplier = 0f;

    int vertexCountX = 0;
    int vertexCountZ = 0;

    int totalVertices = 0;
    int totalIndices = 0;

    //Vector3[][] verticess;
    //int[][] indicess;
    Vector3[] vertices;
    int[] indices;
    Color[] colors;

    [SerializeField] float scale = 1; // size of the grid, aka spacing between vertices



    void Start()
    {
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshFilter = gameObject.AddComponent<MeshFilter>();


        vertexCountX = RectCountOnX + 1;
        vertexCountZ = RectCountOnZ + 1;

        // cap the size of the mesh to the heightmap's size.
        /*if (vertexCountX >= heightmap.width)
            vertexCountX = heightmap.width - 1;
        if (vertexCountZ >= heightmap.height)
            vertexCountZ = heightmap.height - 1;*/

        totalVertices = vertexCountX * vertexCountZ;
        totalIndices = (RectCountOnX * RectCountOnZ) * 6;

        vertices = new Vector3[totalVertices];
        indices = new int[totalIndices];
        colors = new Color[totalVertices];

        //vertices = new Vector3[numberOfTiles * 4][];
        //indices = new int[numberOfTiles * 6][];


        /*
        meshFilter.mesh.vertices = new Vector3[]{
            new Vector3(-0.25f, 0, 0.25f), // upper left
            new Vector3(0.25f, 0, 0.25f), // upper right
            new Vector3(0.25f, 0, -0.25f), // bottom right
            new Vector3(-0.25f, 0, -0.25f) // bottom left
        };

        meshFilter.mesh.triangles = new int[]{ 
            0, 1, 2, 
            2, 3, 0
        }
        */





        /// Vertices
        float xRatio = heightmap.width / vertexCountX;
        float zRatio = heightmap.height / vertexCountZ;

        for (int z = 0; z < vertexCountZ; z++)
        {
            for (int x = 0; x < vertexCountX; x++)
            {
                int vertexIndex = x + z * vertexCountX;

                /*float xGradient = 0;
                float zGradient = 0;

                for (int i = 0; i < xRatio; i++)
                {
                    Color gradient = heightmap.GetPixel(x + i, z + i);
                    xGradient += gradient.grayscale;
                }
                for (int i = 0; i < zRatio; i++)
                {
                    Color gradient = heightmap.GetPixel(x + i, z + i);
                    zGradient += gradient.grayscale;
                }

                xGradient /= xRatio;
                zGradient /= zRatio;*/
                if (xRatio < 1f)
                {
                    xRatio = 1f;
                    print("Warning: The mesh width on X was set wider than the given heightmap size.");
                }

                if (zRatio < 1f)
                {
                    zRatio = 1f;
                    print("Warning: The mesh width on Z was set wider than the given heightmap size.");
                }

                Color height = heightmap.GetPixel((int)(x * xRatio), (int)(z * zRatio));
                colors[vertexIndex] = height;
                vertices[vertexIndex] = new Vector3(x * scale, height.grayscale * heightMultiplier, -z * scale);

                /*verticess[i] = new Vector3[4];
               verticess[i][0] = new Vector3(-i * scale, 0, scale);
               verticess[i][1] = new Vector3(i * scale, 0, scale);
               verticess[i][2] = new Vector3(i * scale, 0, -scale);
               verticess[i][3] = new Vector3(-i * scale, 0, -scale);*/
            }
        }


        /// Indices
        int currentVertex = 0;
        int currentRect = 0; 

        for (int z = 0; z < RectCountOnZ; z++)
        {
            for (int x = 0; x < RectCountOnX; x++)
            {
                indices[currentRect + 0] = currentVertex;
                indices[currentRect + 1] = currentVertex + 1;
                indices[currentRect + 2] = currentVertex + vertexCountX + 1; //should be amount on x
                indices[currentRect + 3] = currentVertex + vertexCountX + 1;
                indices[currentRect + 4] = currentVertex + vertexCountX;
                indices[currentRect + 5] = currentVertex;

                /*indicess[i] = new int[6];
                indicess[i][0] = i;
                indicess[i][1] = i + 1;
                indicess[i][2] = i * vertexRowCount + 1;
                indicess[i][3] = indicess[i][2];
                indicess[i][4] = i * vertexRowCount;
                indicess[i][5] = indicess[i][0];*/
                
                currentVertex++;
                currentRect+=6;
            }

            currentVertex++;
            //j++;
        }


        meshFilter.mesh.vertices = vertices;
        meshFilter.mesh.triangles = indices;
        meshFilter.mesh.colors = colors;



        /*for (int i = 0; i < verticess.Length; i++)
        {
            meshFilter.mesh.vertices = new Vector3[verticess.Length * 4];
            //meshFilter.mesh.vertices[i] 
        }*/
        //meshFilter.mesh.vertices = vertices;
        //meshFilter.mesh.triangles = indices;



        //meshRenderer.material = new Material(shader);

        Debug.Log($"number of vertices: {vertices.Length}\nnumber of indices: {indices.Length}");
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(vertices[0], 1f);
        //Gizmos.DrawSphere(vertices[1], 1f);
        //Gizmos.DrawSphere(vertices[0 + vertexCountX + 1], 1f);

        /*for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], 0.5f);
            //Gizmos.DrawLine(vertices[i], vertices[i + 1]);
        }*/
    }
}
