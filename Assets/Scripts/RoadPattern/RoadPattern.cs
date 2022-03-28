using UnityEngine;

public class RoadPattern : MonoBehaviour
{
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = gameObject.transform.GetChild(i).gameObject;
            
            child.SetActive(true);
        }
    }
}
