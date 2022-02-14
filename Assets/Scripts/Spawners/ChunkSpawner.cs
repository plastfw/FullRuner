using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private Vector3 _firstChunkSpawnPoint;
    [SerializeField] private GameObject[] _traps;

    private List<Chunk> _spawnedChunks = new List<Chunk>();
    private Chunk _firstChunk;
    
    
    public event UnityAction<Vector3> Spawned;

    private void Start()
    {
        _firstChunk = _chunks[Random.Range(0, _chunks.Length)];
        Instantiate(_firstChunk,transform);
        _firstChunk.transform.position = _firstChunkSpawnPoint;
        _spawnedChunks.Add(_firstChunk);
        
        Spawned?.Invoke(_spawnedChunks[0].Start.position);
        
        for (int i = 0; i < 30; i++)
        {
            SpawnChunk();
        }
    }
    
    private void SpawnChunk()
    {
        Chunk newChunk =  Instantiate(_chunks[Random.Range(0, _chunks.Length)],transform);

        newChunk.transform.position = _spawnedChunks[_spawnedChunks.Count - 1].End.position - newChunk.Start.position;
            // new Vector3(0, 0, _spawnedChunks[_spawnedChunks.Count - 1].End.transform.position.z);
        
        Debug.Log(_spawnedChunks[_spawnedChunks.Count-1].End.localPosition.z);

        
        //RandomRotation(newChunk);
            
        _spawnedChunks.Add(newChunk);
    }
    

    private void RandomRotation(Chunk chunk)
    {
        if (_spawnedChunks.Count % 2 == 0) 
        {
            Vector3 newEnd = chunk.Start.transform.position;

            chunk.Start.position = chunk.End.position;
            chunk.End.position = newEnd;
            chunk.transform.Rotate(0,180,0);
        }
    }
}
