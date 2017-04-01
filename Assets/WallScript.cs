using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

    GameObject[] child;

    public int Height
    {
        get { return posX; }
        set
        {
            posX = value;
            transform.position = new Vector3(transform.position.x, posX * GetComponent<Collider>().bounds.size.y, transform.position.z);
        }
    }
    public int Length
    {
        get { return posY; }
        set
        {
            posY = value;
            transform.position = new Vector3(transform.position.x, transform.position.y, posY * GetComponent<Collider>().bounds.size.y);
        }
    }

    private int posX;
    private int posY;

    public WallScript()
    {
        child = new GameObject[10];
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }

}

