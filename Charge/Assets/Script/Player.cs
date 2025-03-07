using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private InputActionReference _mouseLeft;
    [SerializeField] AmmoSpawn ammoSpawn;

    private void Awake()
    {
        if (_mouseLeft == null) return;

        _mouseLeft.action.canceled += OffHold;

        _mouseLeft.action.Enable();

    }
    private void OffHold(InputAction.CallbackContext context)
    {
        ammoSpawn.Ready();
    }
}
