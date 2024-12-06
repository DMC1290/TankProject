using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Projectiles bullet; // projectile we shoot
    [SerializeField] private Transform firePoint; //where projectile spawn
    [SerializeField] private float fireRate = 3f; // Time among every shot

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        // start "AutoFire" coroutine
        StartCoroutine(AutoFire());
    }

    private IEnumerator AutoFire()
    {
        while (true) // infinity cycle to shoot continuously 
        {
            Fire(); // Call "Fire" function
            yield return new WaitForSeconds(fireRate); // Wait before shooting again
        }
    }

    private void Fire()
    {
        // Instanciate projectile on "FirePoint"
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        // check on console if it works
        Debug.Log("Tir effectué !");
    }
}