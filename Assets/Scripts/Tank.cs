using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _force = 200.0f;
    [SerializeField] private float _reverse_force = -200.0f;
    [SerializeField] private float _turnSpeed = 30f;

    private bool _boosterInput = false;
    private bool _reverse_boostInput = false;
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
            _rigidbody.AddForce( transform.forward * _force);
        }

        if (_reverse_boostInput)
        {
            _rigidbody.AddForce(transform.forward * _reverse_force);
        }

        _rigidbody.AddRelativeTorque(0, _turnInput * _turnSpeed, 0);
        Debug.Log(_turnInput);
    }
    
    void OnBoost(InputValue value)
    {
        _boosterInput = value.isPressed;
    }

    void OnReverseBoost(InputValue value)
    {
        _reverse_boostInput = value.isPressed;
    }

    void OnLeftRight(InputValue value)
    {
        _turnInput = value.Get<float>();
    }
}
