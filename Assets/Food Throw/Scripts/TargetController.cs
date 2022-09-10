using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField]
    private float _moveAmplitude, _defaultMoveSpeed;

    private float _timer;

    void Update()
    {
        _timer += Time.deltaTime * _defaultMoveSpeed;
        Vector3 localPosition = transform.localPosition;
        localPosition.x = Mathf.Sin(_timer) * _moveAmplitude;
        transform.localPosition = localPosition;
    }
}
