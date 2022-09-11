using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float TargetRadius;

    [SerializeField]
    private float _moveAmplitude, _defaultMoveSpeed;

    private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.deltaTime * _defaultMoveSpeed;
        Vector3 localPosition = transform.localPosition;
        localPosition.x = Mathf.Sin(_timer) * _moveAmplitude;
        transform.localPosition = localPosition;
    }
}
