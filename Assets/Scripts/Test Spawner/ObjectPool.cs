using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;
    [SerializeField] private int _capacity;

    protected List<Chunk> _pool = new List<Chunk>();

    protected void Initialize(Chunk prefab)
    {
        Chunk spawned = Instantiate(prefab, _container.transform);
        spawned.gameObject.SetActive(false);
        
        _pool.Add(spawned);
    }

    protected bool TryGetObject(out Chunk result)
    {
        result = _pool.First(p => p.gameObject.activeSelf == false);

        return result != null;
    }
}
