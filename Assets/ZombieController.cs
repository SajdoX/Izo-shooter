using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{
    Transform player;
    GameObject enemy;
    NavMeshAgent agent;
    float hp;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        hp = 5;
    }

    // Update is called once per frame
    void Update()
    {
        bool seesPlayer = false;
        bool hearsPlayer = false;

        RaycastHit hit;
        //wektor prowadz¹cy od zombie do gracza
        Vector3 playerVector = player.transform.position - transform.position;

        //"wzrok" zombiaka
        Physics.Raycast(transform.position, playerVector, out hit);
        if (hit.collider.gameObject.CompareTag("Player"))
            seesPlayer = true;

        //znajduje wszstko w promienu 5m
        Collider[] nearby = Physics.OverlapSphere(transform.position, 5f);
        foreach (Collider collider in nearby)
        {
            if (collider.transform.CompareTag("Player"))
            {
                hearsPlayer = true;
            }
        }

        if (seesPlayer || hearsPlayer) {

            agent.destination = player.transform.position;
            agent.isStopped = false;
        
        }
        else
        {
            agent.isStopped = true;
        }

        //transform.LookAt(player.position);
        //transform.Translate(Vector3.forward * Time.deltaTime);

        
    }

    
    public void ReceiveDamage()
    {
        hp -= 1;
        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }



}
