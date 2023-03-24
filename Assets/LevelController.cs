using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    public GameObject zombiePrefab;
    int spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale= 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > spawnTimer)
        {
            Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 1,Random.Range(-10,11 ));
            spawnTimer += 2;
            Instantiate(zombiePrefab, randomSpawnPosition, Quaternion.identity);
        }

    }


}
