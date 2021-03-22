using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float powerupMin = 2.0f;
    public float powerupMax = 60.0f;
    public float powerupVal;
    // Start is called before the first frame update
    void Start()
    {
        powerupVal = Random.Range(powerupMin, powerupMax);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
