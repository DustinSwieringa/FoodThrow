using UnityEngine;
using UnityEngine.Events;

public class ButtonInteractable : MonoBehaviour
{
    public UnityEvent OnButtonPressed;

    [SerializeField]
    private float _minPushDistance;

    private bool _wasPushed;

    private void Update()
    {
        Vector3 localPosition = transform.localPosition;
        localPosition.x = 0;
        localPosition.z = 0;
        localPosition.y = Mathf.Clamp(localPosition.y, _minPushDistance, 0);
        transform.localPosition = localPosition;

        if (!_wasPushed && localPosition.y < _minPushDistance * 0.8f) // Pushed down 80%
        {
            _wasPushed = true;
            OnButtonPressed?.Invoke();
        }
        else if (_wasPushed && localPosition.y > _minPushDistance * 0.5f) // Pushed up 50%
        {
            _wasPushed = false;
        }
    }
}
