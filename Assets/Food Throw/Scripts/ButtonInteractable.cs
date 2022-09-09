using UnityEngine;

public class ButtonInteractable : MonoBehaviour
{
    [SerializeField]
    private float _minPushDistance;

    private void Update()
    {
        Vector3 localPosition = transform.localPosition;
        localPosition.x = 0;
        localPosition.z = 0;
        localPosition.y = Mathf.Clamp(localPosition.y, _minPushDistance, 0);
        transform.localPosition = localPosition;
    }
}
