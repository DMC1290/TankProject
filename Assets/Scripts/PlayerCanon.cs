using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerCanon : MonoBehaviour
{
    [SerializeField] private float _turnSpeed = 2f;
    private float _turnInput = 0f;

    [SerializeField] private GameObject _turret;
    void Start()
    {

    }

    void Update()
    {
        _turret.transform.Rotate(0f,_turnInput * _turnSpeed,0f);
        Debug.Log(_turnInput);
    }

    void OnTurn(InputValue value)
    {
        _turnInput = value.Get<float>();
    }
}
