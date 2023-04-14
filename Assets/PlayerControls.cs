using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    int kills = 0;
    int hp = 10;
    Vector2 inputVector;
    Rigidbody rb;
    public GameObject medkit;
    public GameOverScreen GameOverScreen;

    public void GameOver()
    {
        GameOverScreen.Setup(kills);
    }
  
   void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            hp -= 1;
        }

        if(col.gameObject.tag == "Med")
        {
            hp += 5;
            Destroy(medkit);
        }
    }

    void Death()
    {
        if(hp <= 0)
        {
            Time.timeScale = 0;
            GameOver();

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inputVector = Vector2.zero;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hp);
        Death();
    }
    private void FixedUpdate()
    {
        if(inputVector.y == 0)
        {
            //nie trzymamy wci�ni�tego w ani s
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
}