using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    GameObject enemy;





    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<ZombieController>().ReceiveDamage();
            Debug.Log("Zombie dmg");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<ZombieController>().ReceiveDamage();
            Debug.Log("Zombie dmg");
        }
    }
}
