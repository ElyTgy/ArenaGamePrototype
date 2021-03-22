using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private GameObject powerupIndicator;
    private float powerup = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerupIndicator = GameObject.Find("Powerup indicator");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * Time.deltaTime * speed);
    
        if (powerup > 0)
        {
            powerupIndicator.SetActive(true);
        }
        else
        {
            powerupIndicator.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            powerup += other.gameObject.GetComponent<Powerup>().powerupVal;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && powerup > 0.0f)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 collisionDir = (collision.gameObject.transform.position - transform.position).normalized;

            enemyRb.AddForce(collisionDir * powerup, ForceMode.Impulse);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        powerup = 0.0f;
    }
}
