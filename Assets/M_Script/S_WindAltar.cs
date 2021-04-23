using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_WindAltar : MonoBehaviour
{
    public GameObject windIcon;
    public ParticleSystem windParticle;
    public AudioSource activeSound;
    // Start is called before the first frame update
    void Start()
    {
        windParticle.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            windParticle.Play();
            windIcon.SetActive(true);
            FindObjectOfType<S_PlayerMovement>().windAcitve = true;
            activeSound.Play();
            FindObjectOfType<S_PlayerMovement>().CheckGameWin();
        }
    }
}
