using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float TargetRadius;

    public float MoveSpeedMultiplier { get; set; } = 0.5f;

    [SerializeField]
    private float _moveAmplitude, _defaultMoveSpeed;

    private float _timer;

    private void FixedUpdate()
    {
        _timer += Time.deltaTime * _defaultMoveSpeed * MoveSpeedMultiplier;
        Vector3 localPosition = transform.localPosition;
        localPosition.x = Mathf.Sin(_timer) * _moveAmplitude;
        transform.localPosition = localPosition;
    }
}
