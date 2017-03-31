using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {

    private int width;
    private int height;

    private string seed;
    System.Random pseudoRandom;

    int[,] map;

    void Start()
    {
        width = 7;
        height = 10;
        map = new int[width, height];
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

        for(int y = 0; y< height; y++)
        {
            if(pseudoRandom.Next(0,100) < 75)
                map[(pseudoRandom.Next(0, width/2)), y] = 1;

            if (pseudoRandom.Next(0, 100) < 75)
                map[width / 2, y] = (pseudoRandom.Next(0,2) == 1) ? 1:0;

            if (pseudoRandom.Next(0, 100) < 75)
                map[pseudoRandom.Next(width / 2 + 1, width), y] = 1;
        }
    }



    IEnumerator DrawPlatforms()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if(map[x,y] == 1)
                Instantiate(Resources.Load("TrollPad"), new Vector3(x,0,y),Quaternion.identity);
                yield return null; 
            }
        }
    }

}
