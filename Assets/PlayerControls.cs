using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{

    float hp = 10;
    Vector2 inputVector;
    Rigidbody rb;
    public GameObject bulletPrefab;
    public float bulletSpeed = 20;
    Vector2 movementVector;
    Transform bulletSpawn;

    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;
        rb = GetComponent<Rigidbody>();
        bulletSpawn = transform.Find("BulletSpawn");
    }

    // Update is called once per frame
    void Update()
    {
      

    }
    private void FixedUpdate()
    {
        if(inputVector.y == 0)
        {
            //nie trzymamy wciœniêtego w ani s
            rb.velocity = Vector3.zero;
        }  
        else
        {
            Vector3 movement = transform.forward * inputVector.y;
            rb.AddForce(movement, ForceMode.Impulse);
        }
        if(inputVector.x == 0)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            Vector3 rotation = transform.up * inputVector.x;
            rb.AddTorque(rotation, ForceMode.Impulse);
        }
    }

    void OnMove(InputValue inputValue)
    {
        inputVector = inputValue.Get<Vector2>();
        //Debug.Log("Wykryto ruch kontrolera!");

    }


    void OnFire()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 10, ForceMode.Impulse);
        Destroy(bullet, 5f);
    }
}
