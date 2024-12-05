using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour
{
    [SerializeField] private float _force = 200.0f;
    [SerializeField] private float _turnSpeed = 50f;

    private bool _boosterInput = false;
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

        _rigidbody.AddRelativeTorque(0, _turnInput * _turnSpeed, 0);
        Debug.Log(_turnInput);
    }
    
    void OnBoost(InputValue value)
    {
        _boosterInput = value.isPressed;
    }

    void OnLeftRight(InputValue value)
    {
        _turnInput = value.Get<float>();
    }
}
