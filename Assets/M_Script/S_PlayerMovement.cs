using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_PlayerMovement : MonoBehaviour
{
    public float speed;
    public float playerHealth = 100;
    public S_HealthSilder healthBar;

    [Header("Magic Ball")]
    public GameObject magicBall;
    public Transform magicBallSpawn;

    [Header("Game UI")]
    public GameObject woodUI;
    public GameObject fireUI;
    public GameObject waterUI;
    public GameObject desertUI;

    private int floorMask;
    private float camRayLength = 100f;

    private float attackRate = 2.1f;
    private float nextAttackTime = 0f;
    private Vector3 movement;
    private Rigidbody playerRigidbody;
    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        floorMask = LayerMask.GetMask("Floor");
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        healthBar.SetMaxHealth(100);
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(playerHealth);
        KeyBoardMove();
        Turning();
    }


    private void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    private void KeyBoardMove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            Move(h, v);
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }

        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(magicBall, magicBallSpawn.position, magicBallSpawn.rotation);
                playerAnim.SetBool("isAttack", true);
                nextAttackTime = Time.time + attackRate;
            }
            else
            {
                playerAnim.SetBool("isAttack", false);
            }
        }
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GreenLand")
        {
            print("green");
            woodUI.SetActive(true);
        }
        else
        {
            woodUI.SetActive(false);
        }

        if (collision.gameObject.tag == "BlueLand")
        {
            print("blue");
            waterUI.SetActive(true);
            speed = 5;
        }
        else
        {
            speed = 8;
            waterUI.SetActive(false);
        }
        if (collision.gameObject.tag == "YellowLand")
        {
            print("yellow");
            desertUI.SetActive(true);
        }
        else
        {
            desertUI.SetActive(false);
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "RedLand")
        {
            playerHealth -= Random.Range(0, 2) * Time.deltaTime;
            fireUI.SetActive(true);
        }
        else
        {
            fireUI.SetActive(false);
        }
    }
}
