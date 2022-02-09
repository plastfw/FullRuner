using UnityEngine;

public class Tracking : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _vector3;
    
    void Update()
    {
        transform.position = new Vector3(0, 0, _playerTransform.position.z) + _vector3;
    }
}
