using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    public float waitTime = 3;

    private Rigidbody rb;

    private Vector3 torque;
    private GameObject selected;

    private float timer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        torque = new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
        rb.AddTorque(torque, ForceMode.Impulse);
        selected = null;
    }

    private void FixedUpdate()
    {
        if (timer <= waitTime)
        {
            if (rb.angularVelocity.magnitude < 0.4f)
            {
                rb.angularVelocity = Vector3.zero;
                Debug.Log(transform.localRotation.eulerAngles);
                Vector3 targetRotation = new Vector3(Mathf.Round(transform.localRotation.eulerAngles.x / 90) * 90,
                    Mathf.Round(transform.localRotation.eulerAngles.y / 90) * 90,
                    Mathf.Round(transform.localRotation.eulerAngles.z / 90) * 90);
                transform.localRotation = Quaternion.Euler(targetRotation);
                foreach (Transform item in transform)
                {
                    if (selected == null)
                    {
                        selected = item.gameObject;
                    }
                    else if (item.position.z < selected.transform.position.z)
                    {
                        selected = item.gameObject;
                    }
                }
                Debug.Log(selected.name);
                
                timer += Time.deltaTime;
            }
        }
        else
        {
            if (selected.name.Contains("Player1"))
                BonusManager.Instance.RandomizeBonuses(Randomizer.PlayerSelection.Player1);
            if (selected.name.Contains("Player2"))
                BonusManager.Instance.RandomizeBonuses(Randomizer.PlayerSelection.Player2);
            if (selected.name.Contains("Both"))
                BonusManager.Instance.RandomizeBonuses(Randomizer.PlayerSelection.Both);
            torque = new Vector3(Random.Range(-360f, 360f), Random.Range(-360f, 360f), Random.Range(-360f, 360f));
            rb.AddTorque(torque, ForceMode.Impulse);
            timer = 0.0f;
        }
    }
}
