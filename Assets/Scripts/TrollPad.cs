using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollPad : MonoBehaviour {

    public int worldX {
        set {
            transform.position = new Vector3(value * GetComponent<Collider>().bounds.size.x, transform.position.y, transform.position.z); }
    }
    public int worldY
    {
        set {
            transform.position = new Vector3(transform.position.x, transform.position.y, value * GetComponent<Collider>().bounds.size.y);
        }
    }
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
