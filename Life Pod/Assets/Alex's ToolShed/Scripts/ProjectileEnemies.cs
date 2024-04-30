using System.Collections;
using System.Collections.Generic;
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
}
