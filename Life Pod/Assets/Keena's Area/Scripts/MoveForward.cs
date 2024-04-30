using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    private float speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        if (CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
