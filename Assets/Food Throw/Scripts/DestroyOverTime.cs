using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy = 1f;

    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
