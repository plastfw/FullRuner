using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Vector3 _vector3;
    
    void Update()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, _player.position.z) + _vector3;
    }
}
