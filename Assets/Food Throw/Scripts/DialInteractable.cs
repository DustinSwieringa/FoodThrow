using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class DialInteractable : XRBaseInteractable
{
    public UnityEvent<float> OnValueChanged;

    [SerializeField]
    private Transform _dial;

    [SerializeField]
    private float _maxAngle = 270;

    private Vector3 _previousForward;
    private float _currentAngle;

    private Vector3 CurrentHandForward => firstInteractorSelecting.GetAttachTransform(this).forward;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        _previousForward = CurrentHandForward;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (!isSelected || updatePhase != XRInteractionUpdateOrder.UpdatePhase.Dynamic)
            return;

        Vector3 currentForward = CurrentHandForward;
        float angleDiff = Vector3.SignedAngle(_previousForward, currentForward, _dial.up);
        float newAngle = Mathf.Clamp(_currentAngle + angleDiff, 0, _maxAngle);
        _dial.rotation = Quaternion.AngleAxis(_currentAngle, _dial.up);
        _previousForward = currentForward;

        if (!Mathf.Approximately(_currentAngle, newAngle))
        {
            _currentAngle = newAngle;
            OnValueChanged?.Invoke(_currentAngle / _maxAngle);
        }
    }
}
