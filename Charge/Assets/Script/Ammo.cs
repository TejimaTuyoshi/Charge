using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ammo : MonoBehaviour
{
    [SerializeField] private InputActionReference _hold;
    [SerializeField] bool isHold = false;
    [SerializeField] bool isRemove = false;
    private float power;
    Rigidbody rb;
    private void Awake()
    {
        if (_hold == null) return;

        _hold.action.performed += OnHold;

        _hold.action.canceled += OffHold;

        _hold.action.Enable();

        power = 0;

        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isHold)
        {
            power += 0.01f;
            Debug.Log(power);
        }

        else if(isRemove)
        {
            Debug.Log("”­ŽË!");
            isRemove = false;
            rb.AddForce(-power, power/3, 0, ForceMode.Impulse);
            power = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnHold(InputAction.CallbackContext context)
    {
        isHold = true;
    }

    private void OffHold(InputAction.CallbackContext context)
    {
        isHold = false;
        isRemove = true;
    }
}
