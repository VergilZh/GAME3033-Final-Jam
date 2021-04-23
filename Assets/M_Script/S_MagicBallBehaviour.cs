using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MagicBallBehaviour : MonoBehaviour
{
    public float ballSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * ballSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            other.GetComponent<S_EnemyBehaviour>().GetDamage(10);
            Destroy(gameObject);
        }
    }
}
