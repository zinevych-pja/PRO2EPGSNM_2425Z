using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CollectibleManager : MonoBehaviour
{
    public float startX;
    public float endX;
    public float startZ;
    public float endZ;

    public GameObject _prefab;
    public int collectiblesCount = 10;

    private void Start()
    {
        for (int i = 0; i < collectiblesCount; i++)
        {
            SpawnObject(Random.Range(startX,endX),Random.Range(startZ,endZ));
        }
    }

    public void SpawnObject(float x, float z)
    {
        GameObject obj = Instantiate(_prefab, new Vector3(x, 0.5f, z), Quaternion.identity, transform);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(new Vector3(startX,0,startZ),new Vector3(startX,0,endZ));
        Gizmos.DrawLine(new Vector3(endX,0,startZ),new Vector3(endX,0,endZ));
        Gizmos.DrawLine(new Vector3(startX,0,startZ),new Vector3(endX,0,startZ));
        Gizmos.DrawLine(new Vector3(startX,0,endZ),new Vector3(endX,0,endZ));
    }
}