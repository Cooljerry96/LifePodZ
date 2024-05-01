using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float playerSpeed = 25;
    public GameObject projectilePrefab;

    public AudioSource shotAudio;
    public AudioClip shotClip;
    public AudioClip explosionClip;
    

    // Start is called before the first frame update
    void Start()
    {
        shotAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // lauch a projectile from me
            Instantiate(projectilePrefab, transform.position , transform.rotation);
            shotAudio.PlayOneShot(shotClip, .25f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }
    }
}
