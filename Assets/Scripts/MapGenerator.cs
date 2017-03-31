using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private int width;
    private int length;

    private string seed;
    System.Random pseudoRandom;

    UnityEngine.Object[,] map;

    void Start()
    {
        width = 7;
        length = 10;
        map = new UnityEngine.Object[length, width];
        seed = Guid.NewGuid().ToString();
        RandomGenerateMap();

        StartCoroutine(DrawPlatforms());
    }

    private void Update()
    {
        
    }

    void RandomGenerateMap()
    {
        pseudoRandom = new System.Random(seed.GetHashCode());

        for(int y = 0; y< length; y++)
        {
            //if(pseudoRandom.Next(0,100) < 75)
            //    map[y, (pseudoRandom.Next(0, width / 2))] = 1;

            //if (pseudoRandom.Next(0, 100) < 75)
            //    map[y, width / 2] = (pseudoRandom.Next(0,2) == 1) ? 1:0;

            //if (pseudoRandom.Next(0, 100) < 75)
            //    map[y, pseudoRandom.Next(width / 2 + 1, width)] = 1;

            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(0, width / 2);
                map[y, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(y, 0, rand), Quaternion.identity);
                ((GameObject)map[y, rand]).GetComponent<TrollPad>().worldX = y;
                ((GameObject)map[y, rand]).GetComponent<TrollPad>().worldY = rand;
            }
               

            if (pseudoRandom.Next(0, 100) < 50)
            {
                int rand = pseudoRandom.Next(0, 2);
                map[y, width / 2] = (rand == 1) ? Instantiate(Resources.Load("TrollPad"), new Vector3(y, 0, rand), Quaternion.identity) : null;
                if(map[y, width/2] != null)
                {
                    ((GameObject)map[y, width / 2]).GetComponent<TrollPad>().worldX = y;
                    ((GameObject)map[y, width / 2]).GetComponent<TrollPad>().worldY = width/2;
                }

            }
                

            if (pseudoRandom.Next(0, 100) < 75)
            {
                int rand = pseudoRandom.Next(width / 2 + 1, width);
                map[y, rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(y, 0, rand), Quaternion.identity);
                ((GameObject)map[y, rand]).GetComponent<TrollPad>().worldX = y;
                ((GameObject)map[y, rand]).GetComponent<TrollPad>().worldY = rand;
            }

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

}
