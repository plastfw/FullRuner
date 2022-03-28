using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField]private int _score;

    public event UnityAction<int> HealthChanged;
    public event UnityAction<int> ScoreChanged;
    public event UnityAction Died;

    private void Start()
    {
        ScoreChanged?.Invoke(_score);
        HealthChanged?.Invoke(_health);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Trap trap))
        {
            ApplyDamage();
            trap.gameObject.SetActive(false);
        }

        if (collider.TryGetComponent(out Point point))
        {
            GetScorePoint();
            point.gameObject.SetActive(false);
        }
    }

    private void ApplyDamage()
    {
        _health--;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    private void GetScorePoint()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    private void Die()
    {
        Died?.Invoke();
    }
}
