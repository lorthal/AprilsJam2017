using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    public float speedVertical;
    public float speedHorizontal;
    public float maxVertical;
    public float maxHorizontal;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 vel = new Vector3();

        if (Input.GetKey(KeyCode.UpArrow) && vel.z <= maxHorizontal)
        {
            vel += transform.forward * speedHorizontal;
        } 
        if(Input.GetKey(KeyCode.DownArrow) && vel.z >= -maxHorizontal)
        {
            vel -= transform.forward * speedHorizontal;
        }
        if(Input.GetKey(KeyCode.LeftArrow) && vel.x <= maxVertical)
        {
            vel -= transform.right * speedVertical;
        }
        if (Input.GetKey(KeyCode.RightArrow) && vel.x >= -maxVertical)
        {
            vel += transform.right * speedVertical;
        }
        rb.AddForce(vel);
    }
}
