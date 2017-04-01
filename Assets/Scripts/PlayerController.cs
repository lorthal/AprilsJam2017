using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private bool isGrounded;

    public float speedVertical;
    public float speedHorizontal;
    public float maxVertical;
    public float maxHorizontal;
    public float jumpForce;
    public bool Player1;
    public bool inversedControlls;
    private bool slideControlls;
    public bool SlideControlls
    {
        get
        {
            return slideControlls;
        }
        set
        {
            slideControlls = value;
            if (slideControlls)
                controllsSensitivity = 0.5f;
            else
                controllsSensitivity = 1.0f;
        }
    }
    public float controllsSensitivity = 1.0f;
    public bool isStunned;
    public static float stunRange = 5.0f;
    public static float stunCooldown = 5.0f;
    public static float stunDuration = 2.0f;
    private bool stunUsed;

    public GameObject lastPlatform { get; private set; }
    public int lastPlatformNumber;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        isStunned = false;
        stunUsed = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Player1)
            Player1Input();
        else
            Player2Input();
    }

    void Player1Input()
    {
        if (!isStunned)
        {
            Vector3 vel = new Vector3();
            if ((Input.GetKey(KeyCode.UpArrow) || slideControlls) && vel.z <= maxHorizontal)
            {
                if (!inversedControlls)
                    vel += transform.forward * speedHorizontal * controllsSensitivity;
                else
                    vel -= transform.forward * speedHorizontal;
            }
            if (Input.GetKey(KeyCode.DownArrow) && vel.z >= -maxHorizontal && !slideControlls)
            {
                if (!inversedControlls)
                    vel -= transform.forward * speedHorizontal * controllsSensitivity;
                else
                    vel += transform.forward * speedHorizontal;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && vel.x <= maxVertical)
            {
                if (!inversedControlls)
                    vel -= transform.right * speedVertical * controllsSensitivity;
                else
                    vel += transform.right * speedVertical;
            }
            if (Input.GetKey(KeyCode.RightArrow) && vel.x >= -maxVertical)
            {
                if (!inversedControlls)
                    vel += transform.right * speedVertical * controllsSensitivity;
                else
                    vel -= transform.right * speedVertical;
            }

            if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }
            if (vel.magnitude >= .75f)
                rb.AddForce(vel);

            if (Input.GetKey(KeyCode.RightShift) && !stunUsed)
                StartCoroutine("StunSecondPlayer");
        }
    }

    void Player2Input()
    {
        if (!isStunned)
        {
            Vector3 vel = new Vector3();

            if ((Input.GetKey(KeyCode.W) || slideControlls) && vel.z <= maxHorizontal)
            {
                if (!inversedControlls)
                    vel += transform.forward * speedHorizontal * controllsSensitivity;
                else
                    vel -= transform.forward * speedHorizontal;
            }
            if (Input.GetKey(KeyCode.S) && vel.z >= -maxHorizontal && !slideControlls)
            {
                if (!inversedControlls)
                    vel -= transform.forward * speedHorizontal * controllsSensitivity;
                else
                    vel += transform.forward * speedHorizontal;
            }
            if (Input.GetKey(KeyCode.A) && vel.x <= maxVertical)
            {
                if (!inversedControlls)
                    vel -= transform.right * speedVertical * controllsSensitivity;
                else
                    vel += transform.right * speedVertical;
            }
            if (Input.GetKey(KeyCode.D) && vel.x >= -maxVertical)
            {
                if (!inversedControlls)
                    vel += transform.right * speedVertical * controllsSensitivity;
                else
                    vel -= transform.right * speedVertical;
            }

            if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
            {
                rb.AddForce(transform.up * jumpForce);
            }
            if (vel.magnitude >= .75f)
                rb.AddForce(vel);

            if (Input.GetKey(KeyCode.LeftShift) && !stunUsed)
                StartCoroutine("StunSecondPlayer");
        }
    }

    private IEnumerator StunSecondPlayer()
    {
        if (Vector3.Distance(gameObject.transform.position, GameController.Instance.Player2.transform.position) <= stunRange)
        {
            stunUsed = true;
            StartCoroutine("StunPlayerForSeconds");
        }
        yield return new WaitForSeconds(stunCooldown);
        stunUsed = false;
    }

    private IEnumerator StunPlayerForSeconds()
    {
        if (Player1)
        {
            GameController.Instance.Player2.GetComponent<PlayerController>().isStunned = true;
        }
        else
        {
            GameController.Instance.Player1.GetComponent<PlayerController>().isStunned = true;
        }
        yield return new WaitForSeconds(stunDuration);
        if (Player1)
        {
            GameController.Instance.Player2.GetComponent<PlayerController>().isStunned = false;
        }
        else
        {
            GameController.Instance.Player1.GetComponent<PlayerController>().isStunned = false;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
            lastPlatform = collision.gameObject;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
