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
    private bool isSlidingForward;
    private bool isSlidingBack;
    private bool isSlidingLeft;
    private bool isSlidingRight;
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
                controllsSensitivity = 0.75f;
            else
                controllsSensitivity = 1.0f;
        }
    }
    public float controllsSensitivity = 1.0f;

    //Push ability
    public static float pushRange = 2.0f;
    public static float pushCooldown = 5.0f;
    public static float pushForce = 200.0f;
    private bool pushUsed;
    public bool inversedPush;
    private AudioSource pushSound;
    #endregion

    public GameObject lastPlatform { get; private set; }
    public int lastPlatformNumber;

    // Use this for initialization
    void Start() {
        Rb = GetComponent<Rigidbody>();
        isGrounded = true;
        isSlidingForward = false;
        slideControlls = false;
        pushUsed = false;
        inversedPush = false;
        pushSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (Player1)
            Player1Input();
        else
            Player2Input();
    }

    void Player1Input()
    {
        Vector3 vel = new Vector3();

        if ((Input.GetKey(KeyCode.UpArrow) || (Input.GetAxis("VerticalJoystick2") > 0.0f) || isSlidingForward) && vel.z <= maxHorizontal)
        {
            if(slideControlls && isGrounded && !isSlidingForward)
            {
                StartCoroutine("SlideForwardForSeconds");
            }
            if (!inversedControlls)
                vel += transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel -= transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("VerticalJoystick2") < 0.0f) || isSlidingBack) && vel.z >= -maxHorizontal)
        {
            if (slideControlls && isGrounded && !isSlidingBack)
            {
                StartCoroutine("SlideBackForSeconds");
            }
            if (!inversedControlls)
                vel -= transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel += transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("HorizontalJoystick2") < 0.0f) || isSlidingLeft) && vel.x <= maxVertical)
        {
            if (slideControlls && isGrounded && !isSlidingLeft)
            {
                StartCoroutine("SlideLeftForSeconds");
            }
            if (!inversedControlls)
                vel -= transform.right * speedVertical * controllsSensitivity;
            else
                vel += transform.right * speedVertical;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("HorizontalJoystick2") > 0.0f) || isSlidingRight) && vel.x >= -maxVertical)
        {
            if (slideControlls && isGrounded && !isSlidingRight)
            {
                StartCoroutine("SlideRightForSeconds");
            }
            if (!inversedControlls)
                vel += transform.right * speedVertical * controllsSensitivity;
            else
                vel -= transform.right * speedVertical;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick2Button0)) && isGrounded)
        {
            Rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            Rb.velocity = new Vector3(vel.x, Rb.velocity.y, vel.z);
        else
            Rb.velocity = new Vector3(0, Rb.velocity.y, 0);


        if ((Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.Joystick2Button1)) && !pushUsed)
            StartCoroutine("PushSecondPlayer");
    }

    void Player2Input()
    {
        Vector3 vel = new Vector3();

        if ((Input.GetKey(KeyCode.W) || (Input.GetAxis("VerticalJoystick1") > 0.0f) || isSlidingForward) && vel.z <= maxHorizontal)
        {
            if (slideControlls && isGrounded && !isSlidingForward)
            {
                StartCoroutine("SlideForwardForSeconds");
            }
            if (!inversedControlls)
                vel += transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel -= transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.S) || (Input.GetAxis("VerticalJoystick1") < 0.0f) || isSlidingBack) && vel.z >= -maxHorizontal)
        {
            if (slideControlls && isGrounded && !isSlidingBack)
            {
                StartCoroutine("SlideBackForSeconds");
            }
            if (!inversedControlls)
                vel -= transform.forward * speedHorizontal * controllsSensitivity;
            else
                vel += transform.forward * speedHorizontal;
        }
        if ((Input.GetKey(KeyCode.A) || (Input.GetAxis("HorizontalJoystick1") < 0.0f) || isSlidingLeft) && vel.x <= maxVertical)
        {
            if (slideControlls && isGrounded && !isSlidingLeft)
            {
                StartCoroutine("SlideLeftForSeconds");
            }
            if (!inversedControlls)
                vel -= transform.right * speedVertical * controllsSensitivity;
            else
                vel += transform.right * speedVertical;
        }
        if ((Input.GetKey(KeyCode.D) || (Input.GetAxis("HorizontalJoystick1") > 0.0f) || isSlidingRight) && vel.x >= -maxVertical)
        {
            if (slideControlls && isGrounded && !isSlidingRight)
            {
                StartCoroutine("SlideRightForSeconds");
            }
            if (!inversedControlls)
                vel += transform.right * speedVertical * controllsSensitivity;
            else
                vel -= transform.right * speedVertical;
        }

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && isGrounded)
        {
            Rb.AddForce(transform.up * jumpForce);
        }
        if (vel.magnitude >= .75f)
            Rb.velocity = new Vector3(vel.x, Rb.velocity.y, vel.z);
        else
            Rb.velocity = new Vector3(0, Rb.velocity.y, 0);

        if ((Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Joystick1Button1)) && !pushUsed)
            StartCoroutine("PushSecondPlayer");
    }

    private IEnumerator PushSecondPlayer()
    {
        if (GameController.Instance.Player1 != null && GameController.Instance.Player2 != null)
        {
            if (Vector3.Distance(GameController.Instance.Player1.transform.position, GameController.Instance.Player2.transform.position) <= pushRange)
            {
                pushSound.Play();
                Vector3 relativeTargetPosition;
                pushUsed = true;
                if (Player1)
                {
                    relativeTargetPosition = transform.InverseTransformPoint(GameController.Instance.Player2.transform.position);
                    if (!inversedPush)
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
        }
        yield return new WaitForSeconds(pushCooldown);
        pushUsed = false;
    }

    private IEnumerator SlideForwardForSeconds()
    {
        isSlidingForward = true;
        yield return new WaitForSeconds(1.0f);
        isSlidingForward = false;
    }

    private IEnumerator SlideBackForSeconds()
    {
        isSlidingBack = true;
        yield return new WaitForSeconds(1.0f);
        isSlidingBack = false;
    }

    private IEnumerator SlideLeftForSeconds()
    {
        isSlidingLeft = true;
        yield return new WaitForSeconds(1.0f);
        isSlidingLeft = false;
    }

    private IEnumerator SlideRightForSeconds()
    {
        isSlidingRight = true;
        yield return new WaitForSeconds(1.0f);
        isSlidingRight = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("World"))
        {
            isGrounded = true;
            if(other.gameObject.tag == "Ground")
                lastPlatform = other.gameObject;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("World"))
        {
            isGrounded = false;
        }
    }
}
