using System;
using System.Collections;
using UnityEngine;

public class BonusSlide : BonusBase
{
    private Rigidbody playerRigidbody;
    private PlayerController playerController;
    public float slideSpeed = 10.0f;
    public int numberOfSpins = 1;
    private float rotateSpeed;
    private Quaternion previousPlayerRotation;

    private void Awake()
    {
        Name = "Slide";
        rotateSpeed = 360.0f * numberOfSpins / BonusManager.Instance.timeBetweenBonusesChange;
    }

    public override void Activate(GameObject player)
    {
        base.Activate(player);
        playerRigidbody = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();
        previousPlayerRotation = player.transform.rotation;
        playerController.SlideControlls = true;
        InvokeRepeating("Slide", 0.0f, Time.fixedDeltaTime);
    }

    public override void Deactivate()
    {
        CancelInvoke("Slide");
        transform.rotation = previousPlayerRotation;
        playerController.SlideControlls = false;
        base.Deactivate();
    }

    private void Slide()
    {
        playerRigidbody.velocity = slideSpeed * player.transform.forward;
        //player.transform.Rotate(transform.up, rotateSpeed * Time.fixedDeltaTime);
    }
}
