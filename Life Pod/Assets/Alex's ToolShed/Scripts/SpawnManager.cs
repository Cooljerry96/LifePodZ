using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using System.Security.Cryptography;
using Unity.VisualScripting;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> asteroids;
    public bool isGameActive; //  Put in game manager 
    public float SpawnRate = 1.0f;
    public float xAxis = 46;
    public float yAxis = 36;
    public float zAxis = 0;
    private Vector3[] vectors = new Vector3[4];
   // public float xAxis = 0;
  //  private float yAxis = 0;
    
    private Vector3 pop;
    

    // Start is called before the first frame update
    void Start()
    {

        isGameActive = true;
        StartCoroutine(SpawnAsteroids());

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    IEnumerator SpawnAsteroids()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = UnityEngine.Random.Range(0, asteroids.Count);
            Instantiate(asteroids[index]);
        }
    }





    public Vector3 RandomSpawnPos()
   {
       


        vectors[0] = new Vector3(xAxis,  Random.Range(yAxis, -yAxis), zAxis );
        vectors[1] = new Vector3(-xAxis, Random.Range(yAxis, -yAxis), zAxis );
        vectors[2] = new Vector3(Random.Range(xAxis, -xAxis),-yAxis, zAxis);
        vectors[3] = new Vector3(Random.Range(xAxis, -xAxis), yAxis, zAxis);

        return vectors[Random.Range(0,vectors.Length)];
   }



    /*


    static void RandomNumberGenerator(float xAxis, float yAxis)
   {
      // xAxis =  Random.Range(SpawnManager.leftRightBoarder[0], SpawnManager.leftRightBoarder[1])

     // return new float xAxis = Random.Range(leftRightBoarder[0], leftRightBoarder[1]);
     // return new float yAxis = Random.Range(topBottomBoarder[0], topBottomBoarder[1]);

   }




     return new Vector3(Random.Range(Random.Range(leftRightBoarder[0], leftRightBoarder[1]), -Random.Range(leftRightBoarder[0], leftRightBoarder[1])),// X  Axis lEFT and Right Spawn Area 
                        Random.Range(Random.Range(topBottomBoarder[0], topBottomBoarder[1]), -Random.Range(topBottomBoarder[0], topBottomBoarder[1])), zAxis); // Y Axis  Top and Bottom Spawn Area + hold 0 on the Z axis

    */


}
