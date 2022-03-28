using UnityEngine;
using UnityEngine.Events;

public class ChunkSpawner : ChunkPool
{
    [SerializeField] private int _startingQuantity;
    [SerializeField] private GameObject _player;

    private Chunk _firstChunk;
    private Chunk _lastSpawnedChunk;
    
    public event UnityAction<Chunk> Spawned;
    
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
        
        Spawned?.Invoke(_firstChunk);
    }

    private void Update()
    {
        SpawnChunk();
    }

    private void SpawnChunk()
    {

        if (_player.transform.position.z > _lastSpawnedChunk.transform.position.z - 85)
        {
            if (TryGetObject(out Chunk chunk))
            {
                chunk.transform.position = Vector3.zero;
                chunk.transform.position = _lastSpawnedChunk.End.position - chunk.Start.transform.position; 
                chunk.gameObject.SetActive(true);
                _lastSpawnedChunk = chunk;
            }
        }

    }
}
