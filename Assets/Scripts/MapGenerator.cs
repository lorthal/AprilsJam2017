﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    
    private int width;
    private int length;

    private int currentLength, maxLength;

    private string seed;
    System.Random pseudoRandom;

    UnityEngine.Object[,] map;

    void Start()
    {
        currentLength = 0;
        width = 7;
        length = 10;
        map = new UnityEngine.Object[length, width];
        seed = Guid.NewGuid().ToString();
        RandomGenerateMap();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            GenerateNextPads();
        }
    }

    void RandomGenerateMap()
    {
        pseudoRandom = new System.Random(seed.GetHashCode());

        for (int i = 0; i < width; i++)
        {
            map[0, i] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, i), Quaternion.identity);
            ((TrollPad)map[0, 1]).OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
            ((GameObject)map[0, i]).GetComponent<TrollPad>().worldY = 0;
            ((GameObject)map[0, i]).GetComponent<TrollPad>().worldX = i;
        }

        currentLength++;
        for (int y = 1; y< length; y++)
        {

            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(0, width / 2);
                map[currentLength, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity);
                ((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().worldX = rand;
                ((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().worldY = currentLength;

            }
               

            if (pseudoRandom.Next(0, 100) < 50)
            {
                int rand = pseudoRandom.Next(0, 2);
                map[currentLength, width / 2] = (rand == 1) ? Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity) : null;
                if(map[currentLength, width/2] != null)
                {
                    ((GameObject)map[currentLength, width / 2]).GetComponent<TrollPad>().worldX = width/2;
                    ((GameObject)map[currentLength, width / 2]).GetComponent<TrollPad>().worldY = currentLength;
                }

            }
                

            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(width / 2 + 1, width);
                map[currentLength, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity);
                ((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().worldX = rand;
                ((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().worldY = currentLength;
            }
            currentLength++;
        }

    }



    IEnumerator DrawPlatforms()
    {
        for (int x = 0; x < length; x++)
        {
            for (int y = 0; y < width; y++)
            {
                //if(map[x,y] == 1)
                    //Instantiate(Resources.Load("TrollPad"), new Vector3(x,0,y),Quaternion.identity);
                yield return null; 
            }
        }
    }


    void GenerateNextPads()
    {

        UnityEngine.Object[,] _map = map;
        DestroyFirstRow();
        for (int x = 0; x < length-1; x++)
        {
            for(int y = 0; y < width; y++)
            {
                map[x, y] = _map[x + 1, y];
            }
        }


            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(0, width / 2);
                map[length-1, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity);
                ((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().worldX = rand;
                ((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().worldY = currentLength;

            }


            if (pseudoRandom.Next(0, 100) < 50)
            {
                int rand = pseudoRandom.Next(0, 2);
                map[length - 1, width / 2] = (rand == 1) ? Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity) : null;
                if (map[length - 1, width / 2] != null)
                {
                    ((GameObject)map[length - 1, width / 2]).GetComponent<TrollPad>().worldX = width/2;
                    ((GameObject)map[length - 1, width / 2]).GetComponent<TrollPad>().worldY = currentLength;
                }

            }

            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(width / 2 + 1, width);
                map[length - 1, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity);
                ((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().worldX = rand;
                ((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().worldY = currentLength;
            }
        currentLength++;
    }

    private void DestroyFirstRow()
    {
        for(int i = 0; i < width; i++)
        {
            if (map[0, i] != null)
                ((GameObject)map[0, i]).GetComponent<TrollPad>().Destroy();
        }

    }

    void PlayerEnterPad(object sender, EventArgs e)
    {

    }
}
