using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float force = 200.0f;
    [SerializeField] private float reverseForce = -200.0f;
    [SerializeField] private float turnSpeed = 1f;

    private bool _boosterInput = false;
    private bool _reverseBoostInput = false;
    private float _turnInput = 0f;

    private Rigidbody _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

        if (_rigidbody == null)
        {
            Debug.Log("No rigidbody attached");
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(_boosterInput)
        {
            _rigidbody.AddForce( transform.forward * force);
        }

        if (_reverseBoostInput)
        {
            _rigidbody.AddForce(transform.forward * reverseForce);
        }

        _rigidbody.AddRelativeTorque(0, _turnInput * turnSpeed, 0);
        Debug.Log(_turnInput);
    }
    
    void OnBoost(InputValue value)
    {
        _boosterInput = value.isPressed;
    }

    void OnReverseBoost(InputValue value)
    {
        _reverseBoostInput = value.isPressed;
    }

    void OnLeftRight(InputValue value)
    {
        _turnInput = value.Get<float>();
    }
}
