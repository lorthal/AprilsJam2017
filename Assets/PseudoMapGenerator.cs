using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoMapGenerator : MonoBehaviour
{

    private int width;
    private int currentRowCount;

    private int lastLosingPlayerPlatformNumber;
    private int lastWinningPlayerPlatformNumber;

    private string seed;
    System.Random pseudoRandom;
    private int chanceToSpawnPad;

    List<UnityEngine.Object[]> map;
    List<UnityEngine.Object[]> wallMap;

    void Start()
    {
        width = 9;
        lastLosingPlayerPlatformNumber = 0;
        lastWinningPlayerPlatformNumber = 0;
        seed = Guid.NewGuid().ToString();
        chanceToSpawnPad = 70;
        map = new List<UnityEngine.Object[]>();
        wallMap = new List<UnityEngine.Object[]>();
        pseudoRandom = new System.Random(seed.GetHashCode());

        GenerateSolidRow();
        for (int i = 0; i < 50; i++)
            GenerateRandomRow();
    }

    void Update()
    {
        if (GameController.Instance.Player1 != null && GameController.Instance.Player2 != null)
        {
            if (GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatformNumber <
                        GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatformNumber)
            {
                lastWinningPlayerPlatformNumber = GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatformNumber;
                lastLosingPlayerPlatformNumber = GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatformNumber;
            }
            else
            {
                lastWinningPlayerPlatformNumber = GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatformNumber;
                lastLosingPlayerPlatformNumber = GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatformNumber;
            }
        }


        if (map != null)
        {
                for (int j = 0; j < width; ++j)
                    if ((map[0])[j] != null)
                        if (((GameObject)(map[0])[j]).GetComponent<TrollPad>().Length < lastLosingPlayerPlatformNumber - 3)
                            RemoveFirstRow();
        }


        if (lastWinningPlayerPlatformNumber > currentRowCount - 50)
            GenerateRandomRow();

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
            int rand = pseudoRandom.Next(1, width / 2);
            if (pseudoRandom.Next(0, 100) > 25)
                row[rand] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
            else
                row[rand] = (GameObject)Instantiate(Resources.Load("DisapearingPad"), Vector3.zero, Quaternion.identity);
            ((GameObject)row[rand]).GetComponent<TrollPad>().Length = currentRowCount;
            ((GameObject)row[rand]).GetComponent<TrollPad>().Row = rand;
        }
        if (pseudoRandom.Next(0, 100) < chanceToSpawnPad)
        {
            int rand = pseudoRandom.Next(width / 2 + 1, width - 1);
            if (pseudoRandom.Next(0, 100) > 25)
                row[rand] = (GameObject)Instantiate(Resources.Load("TrollPad"), Vector3.zero, Quaternion.identity);
            else
                row[rand] = (GameObject)Instantiate(Resources.Load("DisapearingPad"), Vector3.zero, Quaternion.identity);
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
        row[0] = (GameObject)Instantiate(Resources.Load("Wall"), Vector3.zero, Quaternion.identity);
        ((GameObject)row[0]).GetComponent<TrollPad>().Length = currentRowCount;
        ((GameObject)row[0]).GetComponent<TrollPad>().Row = 0;
        row[width - 1] = (GameObject)Instantiate(Resources.Load("Wall"), Vector3.zero, Quaternion.identity);
        ((GameObject)row[width - 1]).GetComponent<TrollPad>().Length = currentRowCount;
        ((GameObject)row[width - 1]).GetComponent<TrollPad>().Row = width - 1;



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
        if (currentRowCount > 0)
        {
            foreach (var item in map[0])
            {
                GameObject.Destroy(item);
            }
            map.RemoveAt(0);
        }

    }

}
