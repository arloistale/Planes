using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class DeformSphere : MonoBehaviour
{
    public float noiseScale = 0.1f;
    public float deformationAmount = 0.5f;

    void Start()
    {
        Deform();
    }

    void Deform()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            float noise = Mathf.PerlinNoise(vertices[i].x * noiseScale, vertices[i].y * noiseScale);
            vertices[i] += vertices[i].normalized * noise * deformationAmount;
        }

        mesh.vertices = vertices;
        mesh.RecalculateBounds();
        mesh.RecalculateNormals();
    }
}
