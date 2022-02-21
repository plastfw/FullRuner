using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ChunkPool : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;
    
    protected List<Chunk> _poolChunks = new List<Chunk>();
    
    protected void Initialize()
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
    
    protected bool TryGetObject(out Chunk result)
    {
        result = _poolChunks.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }
    
    protected void RandomRotation(Chunk chunk)
    {
        if (_poolChunks.Count % 2 == 0) 
        {
            Vector3 newEnd = chunk.Start.transform.position;

            chunk.Start.position = chunk.End.position;
            chunk.End.position = newEnd;
            chunk.transform.Rotate(0,180,0);
        }
    }
}