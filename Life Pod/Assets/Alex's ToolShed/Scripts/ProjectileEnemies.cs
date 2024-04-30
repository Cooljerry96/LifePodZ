using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ProjectileEnemies : MonoBehaviour
{
    private  SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        transform.position = spawnManager.RandomSpawnPos();
        
    }

    // Update is called once per frame
    void Update()
    {
  
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);         
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

    }
}
