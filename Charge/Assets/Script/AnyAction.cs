using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class AnyAction : MonoBehaviour
{
    [SerializeField] private InputActionReference _triger;
    [SerializeField] UnityEvent unityEvent;
    [SerializeField] bool _isOn = false;
    private void Awake()
    {
        //InputSystemÇçÃóp
        if (_triger == null) return;

        _triger.action.performed += OnHold;
        _triger.action.canceled += OffHold;
        _triger.action.Enable();
    }

    private void Update()
    {
        if (_isOn) { unityEvent.Invoke() ; }
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        _isOn = true;
    }
    private void OffHold(InputAction.CallbackContext context)
    {
        _isOn = false;
    }
}
