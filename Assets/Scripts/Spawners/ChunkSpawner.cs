using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private GameObject[] _traps;
    [SerializeField] private int _startingQuantity;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _container;

    private List<Chunk> _poolChunks = new List<Chunk>();
    private Chunk _firstChunk;
    private Chunk _lastSpawnedChunk;
    private int _capacity = 10;
    private Chunk chunk;
    
    public event UnityAction<Vector3> Spawned;
    
    private void Start()
    {
        Initialize();
        _firstChunk = _poolChunks[0];
        _firstChunk.transform.position = transform.position;
        _firstChunk.gameObject.SetActive(true);
        _lastSpawnedChunk = _firstChunk;
        
        for (int i = 0; i < _startingQuantity; i++)
        {
            SpawnChunk();
        }
        
        Spawned?.Invoke(_firstChunk.Start.position);
    }

    private void Update()
    {
        if (_player.transform.position.z > _lastSpawnedChunk.transform.position.z-85)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        if (TryGetObject(out Chunk chunk))
        {
            chunk.transform.position = Vector3.zero;
            chunk.transform.position = _lastSpawnedChunk.End.position - chunk.Start.transform.position; 
            chunk.gameObject.SetActive(true);
            _lastSpawnedChunk = chunk;
        }
    }
    
    private void RandomRotation(Chunk chunk)
    {
        if (_poolChunks.Count % 2 == 0) 
        {
            Vector3 newEnd = chunk.Start.transform.position;

            chunk.Start.position = chunk.End.position;
            chunk.End.position = newEnd;
            chunk.transform.Rotate(0,180,0);
        }
    }

    private void Initialize()
    {
        for (int i = 0; i < _capacity / 2; i++) 
        {
            for (int j = 0; j < 2; j++)
            {
                Chunk spawned = Instantiate(_chunks[i],_container.transform);
                RandomRotation(spawned);
                spawned.gameObject.SetActive(false);
                _poolChunks.Add(spawned);
            }
        }
    }
    
    private bool TryGetObject(out Chunk result)
    {
        result = _poolChunks.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
