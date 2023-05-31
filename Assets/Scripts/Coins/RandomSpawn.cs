using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomSpawn : MonoBehaviour
{
    public GameObject ItemPrefab;
    public int coinCount = 50;
    public float heightAboveNavMesh = 1f;

    void Start()
    {
        GenerateCoins();
    }

    void GenerateCoins()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        for (int i = 0; i < coinCount; i++)
        {
            int randomIndex = Random.Range(0, navMeshData.indices.Length - 3);
            Vector3 randomPoint = GetRandomPointOnNavMesh(navMeshData.vertices[navMeshData.indices[randomIndex]],
                                                         navMeshData.vertices[navMeshData.indices[randomIndex + 1]],
                                                         navMeshData.vertices[navMeshData.indices[randomIndex + 2]]);
            randomPoint.y += heightAboveNavMesh; 
            Instantiate(ItemPrefab, randomPoint, Quaternion.identity);
        }
    }

    Vector3 GetRandomPointOnNavMesh(Vector3 x, Vector3 y, Vector3 z)
    {
        float val1 = Random.Range(0f, 1f);
        float val2 = Random.Range(0f, 1f);

        if (val1 + val2 > 1f)
        {
            val1 = 1f - val1;
            val2 = 1f - val2;
        }

        float r3 = 1f - val1 - val2;

        Vector3 point = val1 * x + val2 * y + r3 * z;
        return point;
    }
}
