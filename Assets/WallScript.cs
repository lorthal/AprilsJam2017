﻿using System.Collections;
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

    private void Start()
    {
        for (int i = -5; i < 5; i++)
        {
            child[i + 5] = (GameObject)Instantiate(Resources.Load("Brick"), new Vector3(transform.position.x, GetComponent<Collider>().bounds.size.y * i, transform.position.z), Quaternion.identity);
        }
    }
    public void Destroy()
    {
        
    }
    private void OnDestroy()
    {
        foreach (GameObject item in child)
                {
                    if(child != null)
                    {
                        GameObject.Destroy(item);
                    }
                }
                Destroy(this.gameObject);
    }
}

