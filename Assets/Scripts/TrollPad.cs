using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollPad : MonoBehaviour {
    
    public int worldX {
        get { return posX; }
        set {
            posX = value;
            transform.position = new Vector3(posX * GetComponent<Collider>().bounds.size.x, transform.position.y, transform.position.z); }
    }
    public int worldY
    {
        get { return posY; }
        set {
            posY = value;
            transform.position = new Vector3(transform.position.x, transform.position.y, posY * GetComponent<Collider>().bounds.size.y);
        }
    }

    private int posX;
    private int posY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Destroy()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerPad>().number = posY;
    }

    public void PlayerStepOnPad()
    {
        OnPlayerStepOnPad(this, new EventArgs());
    }
}
