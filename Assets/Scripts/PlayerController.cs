using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public Rigidbody Rb { get; private set; }
    public bool isGrounded { get; private set; }

    public float speedVertical;
    public float speedHorizontal;
    public float maxVertical;
    public float maxHorizontal;
    public float jumpForce;
    public bool Player1;

    #region Bonuses fields
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

    //Push ability
    public static float pushRange = 2.0f;
    public static float pushCooldown = 5.0f;
    public static float pushForce = 10.0f;
    private bool pushUsed;
    public bool inversedPush;
    #endregion

    public GameObject lastPlatform { get; private set; }
    public int lastPlatformNumber;

	// Use this for initialization
	void Start () {
        Rb = GetComponent<Rigidbody>();
        isGrounded = true;
        pushUsed = false;
        inversedPush = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Player1)
            Player1Input();
        else
            Player2Input();

        //Temporary restart level
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("main");
        }
    }

    void Player1Input()
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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            Rb.velocity = new Vector3(vel.x, Rb.velocity.y, vel.z);
        else
            Rb.velocity = new Vector3(0, Rb.velocity.y, 0);


        if (Input.GetKey(KeyCode.LeftControl) && !pushUsed)
            StartCoroutine("PushSecondPlayer");
    }

    void Player2Input()
    {
        Vector3 vel = new Vector3();
        if ((Input.GetKey(KeyCode.W) || (Input.GetAxis("VerticalJoystick") > 0.0f) || slideControlls) && vel.z <= maxHorizontal)
        {
            if (!inversedControlls)
                vel += transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel -= transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.S) || Input.GetAxis("VerticalJoystick") < 0.0f) && vel.z >= -maxHorizontal && !slideControlls)
        {
            if (!inversedControlls)
                vel -= transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel += transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetAxis("HorizontalJoystick") < 0.0f) && vel.x <= maxVertical)
        {
            if (!inversedControlls)
                vel -= transform.right * speedVertical * controllsSensitivity;
            else
                vel += transform.right * speedVertical;
        }
        if ((Input.GetKey(KeyCode.D) || Input.GetAxis("HorizontalJoystick") > 0.0f) && vel.x >= -maxVertical)
        {
            if (!inversedControlls)
                vel += transform.right * speedVertical * controllsSensitivity;
            else
                vel -= transform.right * speedVertical;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.JoystickButton0)) && isGrounded)
        {
            Rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            Rb.AddForce(vel);

        if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.JoystickButton1)) && !pushUsed)
            StartCoroutine("PushSecondPlayer");
    }

    private IEnumerator PushSecondPlayer()
    {
        if (Vector3.Distance(GameController.Instance.Player1.transform.position, GameController.Instance.Player2.transform.position) <= pushRange)
        {
            Vector3 relativeTargetPosition;
            pushUsed = true;
            if (Player1)
            {
                relativeTargetPosition = transform.InverseTransformPoint(GameController.Instance.Player2.transform.position);
                if(!inversedPush)
                {
                    if (relativeTargetPosition.x > 0.0f)
                        GameController.Instance.Player2.GetComponent<PlayerController>().Rb.AddForce(GameController.Instance.Player2.transform.right * pushForce, ForceMode.Impulse);
                    else
                        GameController.Instance.Player2.GetComponent<PlayerController>().Rb.AddForce(-GameController.Instance.Player2.transform.right * pushForce, ForceMode.Impulse);
                }
                else
                {
                    if (relativeTargetPosition.x > 0.0f)
                        GameController.Instance.Player1.GetComponent<PlayerController>().Rb.AddForce(-GameController.Instance.Player1.transform.right * pushForce, ForceMode.Impulse);
                    else
                        GameController.Instance.Player1.GetComponent<PlayerController>().Rb.AddForce(GameController.Instance.Player1.transform.right * pushForce, ForceMode.Impulse);
                }
            }
            else
            {
                relativeTargetPosition = transform.InverseTransformPoint(GameController.Instance.Player1.transform.position);
                if (!inversedPush)
                {
                    if (relativeTargetPosition.x > 0.0f)
                        GameController.Instance.Player1.GetComponent<PlayerController>().Rb.AddForce(GameController.Instance.Player1.transform.right * pushForce, ForceMode.Impulse);
                    else
                        GameController.Instance.Player1.GetComponent<PlayerController>().Rb.AddForce(-GameController.Instance.Player1.transform.right * pushForce, ForceMode.Impulse);
                }
                else
                {
                    if (relativeTargetPosition.x > 0.0f)
                        GameController.Instance.Player2.GetComponent<PlayerController>().Rb.AddForce(-GameController.Instance.Player2.transform.right * pushForce, ForceMode.Impulse);
                    else
                        GameController.Instance.Player2.GetComponent<PlayerController>().Rb.AddForce(GameController.Instance.Player2.transform.right * pushForce, ForceMode.Impulse);
                }
            }
        }
        yield return new WaitForSeconds(pushCooldown);
        pushUsed = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            lastPlatform = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
