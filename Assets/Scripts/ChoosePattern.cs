using UnityEngine;
using Random = UnityEngine.Random;

public class ChoosePattern : MonoBehaviour
{
    [SerializeField] private GameObject _pointToPatern;

    private GameObject _activeTrap;

    private void Start()
    {
        Choose();
    }

    private void Choose()
    {
        _activeTrap = gameObject.transform.GetChild(Random.Range(0, 2)).gameObject;
        _activeTrap.transform.position = _pointToPatern.transform.position;
        TryChangeRotation(_activeTrap);
        _activeTrap.SetActive(true);
    }
    
    private void TryChangeRotation(GameObject pattern)
    {
        if (GetRandomRotation())
        {
            pattern.transform.Rotate(0, 180, 0);
        }
    }

    private bool GetRandomRotation()
    {
        int randomNumber = Random.Range(1, 10);

        if (randomNumber % 2 == 0) 
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
