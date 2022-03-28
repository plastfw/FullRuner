using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;

    public Transform End => _end;
    public Transform Start => _start;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ChunkDestroyer destroyer))
        {
            gameObject.SetActive(false);
        }
    }
}