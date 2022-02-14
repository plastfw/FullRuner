using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : ObjectPool
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Transform _player;

    private Chunk _firstChunk;

    private void Start()
    {
        _firstChunk = _chunks[Random.Range(0, _chunks.Length)];
        Initialize(_firstChunk);
    }

    private void Update()
    {
        if (_player.position.z > _pool[0].transform.position.z)
        {
            
        }
    }

    private void SetChunk(Chunk chunk)
    {
        chunk.gameObject.SetActive(true);
        chunk.transform.position = _pool[_pool.Count - 1].End.position - chunk.Start.position;
    }
}
