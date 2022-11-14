using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    private InputActionProperty _openMenuAction;

    [SerializeField]
    private Canvas _optionsMenuCanvas;

    [SerializeField]
    private Transform _cameraTransform;

    [SerializeField]
    private float _canvasSpawnDistance;

    [SerializeField]
    private float _optionsMenuCloseDistance;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    private void Awake()
    {
        _openMenuAction.reference.action.performed += Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        _optionsMenuCanvas.enabled = !_optionsMenuCanvas.enabled;

        if (_optionsMenuCanvas.enabled)
        {
            Vector3 targetPosition = _cameraTransform.TransformPoint(0, 0, _canvasSpawnDistance);
            targetPosition.y = _cameraTransform.position.y;
            _optionsMenuCanvas.transform.position = targetPosition;
            _optionsMenuCanvas.transform.LookAt(_cameraTransform);
        }
    }

    private void Update()
    {
        if (_optionsMenuCanvas.enabled)
        {
            float distanceFromCanvas = Vector3.Distance(_optionsMenuCanvas.transform.position, _cameraTransform.position);
            if (distanceFromCanvas > _optionsMenuCloseDistance)
            {
                _optionsMenuCanvas.enabled = false;
            }
        }
    }
}
