using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;

    private void Start()
    {
        transform.position = _player.position;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 0 + _yOffset, _player.position.z + _zOffset);
    }
}
