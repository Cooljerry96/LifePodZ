using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGravity : MonoBehaviour
{
    public Transform planet;
    public bool alignToPlanet = true;

    public float gravityConstant;
    Rigidbody rb;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    void Update()
    {
        Vector3 toCenter = planet.position - transform.position;
        toCenter.Normalize();


        rb.AddForce(toCenter * gravityConstant, ForceMode.Acceleration);

        if (alignToPlanet)
        {
            Quaternion q = Quaternion.FromToRotation(transform.up, -toCenter);
            q = q * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, q, 1);
        }
    }
}