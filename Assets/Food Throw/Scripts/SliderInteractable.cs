using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class SliderInteractable : XRBaseInteractable
{
    public UnityEvent<float> OnValueChanged;

    [SerializeField]
    private float _localMoveDistance;

    [SerializeField]
    private Transform _slider;

    private float _currentSliderValue = 0.5f;

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (!isSelected || updatePhase != XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            return;

        Vector3 localPosition = _slider.localPosition;
        Vector3 worldHandPosition = firstInteractorSelecting.GetAttachTransform(this).position;
        Vector3 localHandPosition = _slider.parent.InverseTransformPoint(worldHandPosition);
        localPosition.z = Mathf.Clamp(localHandPosition.z, -_localMoveDistance, _localMoveDistance);
        _slider.localPosition = localPosition;

        float sliderMaxRange = _localMoveDistance + _localMoveDistance;
        float sliderValue = localPosition.x + _localMoveDistance;
        float sliderRatio = sliderValue / sliderMaxRange;

        if (!Mathf.Approximately(sliderRatio, _currentSliderValue))
        {
            _currentSliderValue = sliderRatio;
            OnValueChanged?.Invoke(sliderRatio);
        }
    }
}
