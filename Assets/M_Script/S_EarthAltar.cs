using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EarthAltar : MonoBehaviour
{
    public GameObject earthIcon;
    public ParticleSystem earthParticle;
    public AudioSource activeSound;
    // Start is called before the first frame update
    void Start()
    {
        earthParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            earthParticle.Play();
            earthIcon.SetActive(true);
            FindObjectOfType<S_PlayerMovement>().earthAcitve = true;
            activeSound.Play();
            FindObjectOfType<S_PlayerMovement>().CheckGameWin();
        }
    }
}
