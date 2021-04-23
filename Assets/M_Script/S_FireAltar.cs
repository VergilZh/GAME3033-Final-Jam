using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FireAltar : MonoBehaviour
{
    public GameObject fireIcon;
    public ParticleSystem fireParticle;
    public GameObject fireEffect;
    public AudioSource activeSound;
    // Start is called before the first frame update
    void Start()
    {
        fireParticle.Stop();
        fireEffect.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            fireParticle.Play();
            fireEffect.SetActive(true);
            fireIcon.SetActive(true);
            activeSound.Play();
            FindObjectOfType<S_PlayerMovement>().fireAcitve = true;
            FindObjectOfType<S_PlayerMovement>().CheckGameWin();
        }
    }
}
