using System;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [SerializeField] private float bulletForce = 30f;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GetComponent<Rigidbody>().linearVelocity = transform.forward * bulletForce;
        
        Destroy(gameObject, 2);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter ??? : " + other.gameObject.name);
        
        // if (other.gameObject.CompareTag("Destructible"))
        // {
        // Destroy(other.gameObject, 2);
        // Destroy(this.gameObject);
        // }

        if (other.gameObject.TryGetComponent(out Destroy objective))
        {
            objective.TakeDamage(5);
        }
    }


    private void OnCollisionStay(Collision other)
    {
        throw new NotImplementedException();
    }

    private void OnCollisionExit(Collision other)
    {
        throw new NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        throw new NotImplementedException();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
