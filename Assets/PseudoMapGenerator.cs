﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoMapGenerator : MonoBehaviour
{

    private int width;
    private int startLength;
    private int currentRowCount;

    private int lastLosingPlayerPlatformNumber;
    private int lastWinningPlayerPlatformNumber;

    private string seed;
    System.Random pseudoRandom;
    private int chanceToSpawnPad;

    List<UnityEngine.Object[]> map;

    void Start()
    {
        width = 9;
        startLength = 30;
        lastLosingPlayerPlatformNumber = 0;
        lastWinningPlayerPlatformNumber = 0;
        seed = Guid.NewGuid().ToString();
        chanceToSpawnPad = 70;
        map = new List<UnityEngine.Object[]>();
        pseudoRandom = new System.Random(seed.GetHashCode());
    }

    void Update()
    {
        Debug.Log(currentRowCount);
        if (Input.GetMouseButtonDown(0))
        {
            GenerateRandomRow();
        }
        if (Input.GetMouseButtonDown(1))
        {
            RemoveFirstRow();
        }
        if (Input.GetMouseButtonDown(2))
        {
            GenerateSolidRow();
        }
    }

    void GenerateRandomRow()
    {
        GameObject[] row = new GameObject[width];
        if (pseudoRandom.Next(0, 100) < chanceToSpawnPad)
        {
            int rand = pseudoRandom.Next(0, width / 2);
            row[rand] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
            ((GameObject)row[rand]).GetComponent<TrollPad>().Length = currentRowCount;
            ((GameObject)row[rand]).GetComponent<TrollPad>().Row = rand;
        }
        if (pseudoRandom.Next(0, 100) < chanceToSpawnPad)
        {
            int rand = pseudoRandom.Next(width / 2 + 1, width);
            row[rand] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
            ((GameObject)row[rand]).GetComponent<TrollPad>().Length = currentRowCount;
            ((GameObject)row[rand]).GetComponent<TrollPad>().Row = rand;
        }
        if (pseudoRandom.Next(0, 100) < 60)
        {
            int rand = pseudoRandom.Next(0, 2);
            row[width / 2] = (rand == 1) ? (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity) : null;


            if (rand == 1)
            {
                row[width / 2] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
                ((GameObject)row[width / 2]).GetComponent<TrollPad>().Length = currentRowCount;
                ((GameObject)row[width / 2]).GetComponent<TrollPad>().Row = width / 2;
            }
            else
            {
                row[width / 2] = null;
            }

        }
        map.Add(row);
        currentRowCount++;
    }

    void GenerateSolidRow()
    {
        GameObject[] row = new GameObject[width];
        for (int i = 0; i < width; i++)
        {
            if (i == 0)
            {
                row[i] = (GameObject)Instantiate(Resources.Load("Wall"), Vector3.zero, Quaternion.identity);
                ((GameObject)row[i]).GetComponent<TrollPad>().Length = currentRowCount;
                ((GameObject)row[i]).GetComponent<TrollPad>().Row = i;
            }
            else if (i == width - 1)
            {
                row[i] = (GameObject)Instantiate(Resources.Load("Wall"), Vector3.zero, Quaternion.identity);
                ((GameObject)row[i]).GetComponent<TrollPad>().Length = currentRowCount;
                ((GameObject)row[i]).GetComponent<TrollPad>().Row = i;
            }
            else
            {
                row[i] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
                ((GameObject)row[i]).GetComponent<TrollPad>().Length = currentRowCount;
                ((GameObject)row[i]).GetComponent<TrollPad>().Row = i;
            }
        }
        map.Add(row);
        currentRowCount++;
    }

    void RemoveFirstRow()
    {
        foreach (var item in map[0])
        {
            GameObject.Destroy(item);
        }
        map.RemoveAt(0);
    }

}
