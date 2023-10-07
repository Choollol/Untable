using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int number;
    [SerializeField] private Vector2 bounds;
    [SerializeField] private Transform parent;
    void Awake()
    {
        for (int i = 0; i < number; i++)
        {
            Instantiate(prefab, new Vector3(Random.Range(-bounds.x, bounds.x), Random.Range(-bounds.y, bounds.y)), 
                Quaternion.identity, parent);
        }
    }
}
