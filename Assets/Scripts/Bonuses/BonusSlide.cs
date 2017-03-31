using System;
using System.Collections;
using UnityEngine;

public class BonusSlide : BonusBase
{
    private Rigidbody playerRigidbody;
    private PlayerController playerController;
    public float slideSpeed = 10.0f;
    public int numberOfSpins = 2;
    private float rotateSpeed;

    private void Start()
    {
        rotateSpeed = 360.0f * numberOfSpins / duration;
    }

    public override void ApplyBonus(GameObject player)
    {
        this.player = player;
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
        StartCoroutine("SlideForSeconds");
    }

    private IEnumerator SlideForSeconds()
    {
        playerController.enabled = false;
        playerRigidbody.velocity = slideSpeed * player.transform.forward;
        //InvokeRepeating("RotateWhileSliding", Time.fixedDeltaTime, Time.fixedDeltaTime);
        yield return new WaitForSeconds(duration);
        //CancelInvoke("RotateWhileSliding");
        playerRigidbody.velocity = Vector3.zero;
        playerController.enabled = true;
        Destroy(gameObject);
    }

    private void RotateWhileSliding()
    {
        player.transform.Rotate(transform.up, rotateSpeed * Time.fixedDeltaTime);
    }
}
