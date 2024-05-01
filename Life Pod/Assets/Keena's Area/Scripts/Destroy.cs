using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private PlayerMovement playerMovementAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerMovementAudio = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (transform.position.x > 93 || transform.position.x < -93 || transform.position.y < -56 || transform.position.y > 56)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            playerMovementAudio.shotAudio.PlayOneShot(playerMovementAudio.explosionClip, 1);
        }
        if (collision.gameObject.CompareTag("Planet"))
        {
            Destroy(gameObject);
        }

    }

}
