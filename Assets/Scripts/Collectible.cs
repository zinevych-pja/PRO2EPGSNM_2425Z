using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Collectible : MonoBehaviour
{
    private Collider _collider;
    
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        CollectibleController collectibleController = other.GetComponent<CollectibleController>();
        collectibleController.Increase();
        Destroy(gameObject);
    }
}