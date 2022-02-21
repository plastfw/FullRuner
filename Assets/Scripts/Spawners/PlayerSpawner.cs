using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ChunkSpawner _chunkSpawner;

    private void OnEnable()
    {
        _chunkSpawner.Spawned += ChangePosition;
    }

    private void OnDisable()
    {
        _chunkSpawner.Spawned -= ChangePosition;
    }

    private void ChangePosition(Vector3 startPosition)
    {
        _player.transform.position = startPosition + new Vector3(0,0,5);
    }
}