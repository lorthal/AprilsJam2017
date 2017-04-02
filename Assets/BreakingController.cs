using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingController : MonoBehaviour {

    public float breakTime;

    private ParticleSystem burst;

    private float timer;
    private bool triggered;

    private void Start()
    {
        timer = 0;
        burst = ((GameObject)Instantiate(Resources.Load("BreakingBurst"), transform.position, Quaternion.identity)).GetComponent<ParticleSystem>();
        triggered = false;
    }

    private void Update()
    {
        if (timer >= breakTime)
        {
            triggered = false;
            timer = 0;
            burst.Play();
            Destroy(gameObject);
        }
        if(triggered)
            timer += Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
}
