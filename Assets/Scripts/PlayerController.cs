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
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
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
        Vector3 vel = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow) && vel.z <= maxHorizontal)
        {
            vel += transform.forward * speedHorizontal;
        }
        if (Input.GetKey(KeyCode.DownArrow) && vel.z >= -maxHorizontal)
        {
            vel -= transform.forward * speedHorizontal;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && vel.x <= maxVertical)
        {
            vel -= transform.right * speedVertical;
        }
        if (Input.GetKey(KeyCode.RightArrow) && vel.x >= -maxVertical)
        {
            vel += transform.right * speedVertical;
        }
        if (Input.GetKeyDown(KeyCode.RightControl) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            rb.AddForce(vel);
    }

    void Player2Input()
    {
        Vector3 vel = new Vector3();

        if (Input.GetKey(KeyCode.W) && vel.z <= maxHorizontal)
        {
            vel += transform.forward * speedHorizontal;
        }
        if (Input.GetKey(KeyCode.S) && vel.z >= -maxHorizontal)
        {
            vel -= transform.forward * speedHorizontal;
        }
        if (Input.GetKey(KeyCode.A) && vel.x <= maxVertical)
        {
            vel -= transform.right * speedVertical;
        }
        if (Input.GetKey(KeyCode.D) && vel.x >= -maxVertical)
        {
            vel += transform.right * speedVertical;
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            rb.AddForce(vel);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
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
