using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WaterAltar : MonoBehaviour
{
    public ParticleSystem waterParticle;
    // Start is called before the first frame update
    void Start()
    {
        waterParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            waterParticle.Play();
        }
    }
}
