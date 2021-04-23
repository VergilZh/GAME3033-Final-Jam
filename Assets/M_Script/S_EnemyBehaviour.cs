using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_EnemyBehaviour : MonoBehaviour
{
    public Transform target;
    public float speed;
    public float enemyAttack;
    public AudioSource hit;
    public int EnemyHealth = 100;

    private Rigidbody rig;
    private Animator EnemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rig = GetComponent<Rigidbody>();
        EnemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollowTarget();

        if (EnemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void GetDamage(int damage)
    {
        EnemyHealth -= damage;
        hit.Play();
    }

    void EnemyFollowTarget()
    {
        Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rig.MovePosition(position);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<S_PlayerMovement>().playerHealth -= enemyAttack;
        }
    }
}
