using UnityEngine;
using UnityEngine.Events;

public class ChunkSpawner : ChunkPool
{
    [SerializeField] private int _startingQuantity;
    [SerializeField] private GameObject _player;

    private Chunk _first;
    private Chunk _lastSpawned;
    
    public event UnityAction<Chunk> Spawned;
    
    private void Start()
    {
        Initialize();
        _first = _poolChunks[0];
        _first.transform.position = transform.position;
        _first.gameObject.SetActive(true);
        _lastSpawned = _first;
        
        
        for (int i = 0; i < _startingQuantity; i++)
        {
            SpawnChunk();
        }
        
        Spawned?.Invoke(_first);
    }

    private void Update()
    {
        SpawnChunk();
    }

    private void SpawnChunk()
    {

        if (_player.transform.position.z > _lastSpawned.transform.position.z - 85)
        {
            if (TryGetObject(out Chunk chunk))
            {
                chunk.transform.position = Vector3.zero;
                chunk.transform.position = _lastSpawned.End.position - chunk.Start.transform.position; 
                chunk.gameObject.SetActive(true);
                _lastSpawned = chunk;
            }
        }

    }
}
