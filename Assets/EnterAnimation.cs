using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAnimation : MonoBehaviour
{
    public float difference = 0.1f;
    public float animSpeed;

    private Vector3 targetPos;
    private Vector3 defaultPos;
    bool down;
    bool animate;

    private void Start()
    {
        defaultPos = transform.position;
        targetPos = new Vector3(transform.position.x, transform.position.y - difference, transform.position.z);
        down = true;
        animate = false;
    }

    private void FixedUpdate()
    {
        if (animate)
        {
            if (Mathf.Abs(transform.position.y - targetPos.y) >= 0.1f && down)
            {
                transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * animSpeed);
            }
            else if (Mathf.Abs(transform.position.y - defaultPos.y) >= 0.05)
            {
                down = false;
                transform.position = Vector3.Lerp(transform.position, defaultPos, Time.deltaTime * animSpeed / 4);
            }
            else
            {
                transform.position = defaultPos;
                animate = false;
                down = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !other.gameObject.GetComponent<PlayerController>().isGrounded)
        {
            animate = true;
        }
    }
}
