using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    [SerializeField] private Transform[] _spawnPointsToTrap;
    
    public Transform End => _end;
    public Transform Start => _start;

    public Transform[] SpawnPointsToTrap => _spawnPointsToTrap;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ChunkDestroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }
}