//using Assets.Scripts;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class MapGenerator : MonoBehaviour
//{

//    private int width;
//    private int numberOfColumns;

//    private int currentLength;

//    private int lastPlayerPlatformNumber;

//    private string seed;
//    System.Random pseudoRandom;

//    //UnityEngine.Object[,] map;
//    List<UnityEngine.Object[]> map;

//    void Start()
//    {
//        lastPlayerPlatformNumber = 0;
//        currentLength = 0;
//        width = 9;
//        numberOfColumns = 30;
//        map = new List<UnityEngine.Object[]>();
//        seed = Guid.NewGuid().ToString();
//        RandomGenerateMap();
//    }

//    private void Update()
//    {


//        if (lastPlayerPlatformNumber < GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatformNumber)
//        {
//            lastPlayerPlatformNumber = GameController.Instance.Player2.GetComponent<PlayerController>().lastPlatformNumber;
//            for (int i = 0; i < 5; i++)
//                GenerateNextPads();
//        }
//        if (lastPlayerPlatformNumber < GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatformNumber)
//        {
//            lastPlayerPlatformNumber = GameController.Instance.Player1.GetComponent<PlayerController>().lastPlatformNumber;
//            for (int i = 0; i < 5; i++)
//                GenerateNextPads();
//        }
//    }

//    void RandomGenerateMap()
//    {
//        pseudoRandom = new System.Random(seed.GetHashCode());

//        for (int i = 0; i < width; i++)
//        {
//            if (i == 0)
//            {
//                map[0][i] = Instantiate(Resources.Load("Wall"), new Vector3(currentLength, 0, i), Quaternion.identity);
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldY = 0;
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldX = 0;
//            }
//            else if (i >= 1 && i < width - 1)
//            {
//                map[0][i] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, i), Quaternion.identity);
//                //((GameObject)map[0, i]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldY = 0;
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldX = i;
//            }
//            else if (i == width - 1)
//            {
//                map[0][i] = Instantiate(Resources.Load("Wall"), new Vector3(currentLength, 0, i), Quaternion.identity);
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldY = 0;
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().worldX = i;
//            }

//        }

//        currentLength++;
//        for (int y = 1; y < length; y++)
//        {
//            map[y][0] = Instantiate(Resources.Load("Wall"), new Vector3(currentLength, 0, y), Quaternion.identity);
//            ((GameObject)map[y][0]).GetComponent<TrollPad>().worldY = y;
//            ((GameObject)map[y][0]).GetComponent<TrollPad>().worldX = 0;
//            map[y][width - 1] = Instantiate(Resources.Load("Wall"), new Vector3(currentLength, 0, y), Quaternion.identity);
//            ((GameObject)map[y][width - 1]).GetComponent<TrollPad>().worldY = y;
//            ((GameObject)map[y][width - 1]).GetComponent<TrollPad>().worldX = width - 1;

//            if (pseudoRandom.Next(0, 100) < 75)
//            {
//                int rand = pseudoRandom.Next(1, width / 2);
//                map[currentLength][rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity);
//                ((GameObject)map[currentLength][rand]).GetComponent<TrollPad>().worldX = rand;
//                ((GameObject)map[currentLength][rand]).GetComponent<TrollPad>().worldY = currentLength;
//                //((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);

//            }


//            if (pseudoRandom.Next(0, 100) < 50)
//            {
//                int rand = pseudoRandom.Next(0, 2);
//                map[currentLength][width / 2] = (rand == 1) ? Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity) : null;
//                if (map[currentLength][width / 2] != null)
//                {
//                    ((GameObject)map[currentLength][width / 2]).GetComponent<TrollPad>().worldX = width / 2;
//                    ((GameObject)map[currentLength][width / 2]).GetComponent<TrollPad>().worldY = currentLength;
//                    //((GameObject)map[currentLength, width / 2]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
//                }

//            }


//            if (pseudoRandom.Next(0, 100) < 75)
//            {
//                int rand = pseudoRandom.Next(width / 2 + 1, width);
//                map[currentLength][rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(currentLength, 0, rand), Quaternion.identity);
//                ((GameObject)map[currentLength][rand]).GetComponent<TrollPad>().worldX = rand;
//                ((GameObject)map[currentLength][rand]).GetComponent<TrollPad>().worldY = currentLength;
//                //((GameObject)map[currentLength, rand]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
//            }
//            currentLength++;
//        }

//    }



//    IEnumerator DrawPlatforms()
//    {
//        for (int x = 0; x < length; x++)
//        {
//            for (int y = 0; y < width; y++)
//            {
//                //if(map[x,y] == 1)
//                //Instantiate(Resources.Load("TrollPad"), new Vector3(x,0,y),Quaternion.identity);
//                yield return null;
//            }
//        }
//    }


//    void GenerateNextPads()
//    {

//        //UnityEngine.Object[,] _map = map;
//        //DestroyFirstRow();
//        //for (int x = 0; x < length-1; x++)
//        //{
//        //    for(int y = 0; y < width; y++)
//        //    {
//        //        map[x, y] = _map[x + 1, y];
//        //    }
//        //}


//        if (pseudoRandom.Next(0, 100) < 75)
//        {
//            int rand = pseudoRandom.Next(0, width / 2);
//            map[length - 1][rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity);
//            ((GameObject)map[length - 1][rand]).GetComponent<TrollPad>().worldX = rand;
//            ((GameObject)map[length - 1][rand]).GetComponent<TrollPad>().worldY = currentLength;
//            //((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);

//        }


//        if (pseudoRandom.Next(0, 100) < 50)
//        {
//            int rand = pseudoRandom.Next(0, 2);
//            map[length - 1][width / 2] = (rand == 1) ? Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity) : null;
//            if (map[length - 1][width / 2] != null)
//            {
//                ((GameObject)map[length - 1][width / 2]).GetComponent<TrollPad>().worldX = width / 2;
//                ((GameObject)map[length - 1][width / 2]).GetComponent<TrollPad>().worldY = currentLength;
//                //((GameObject)map[length - 1, width / 2]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
//            }

//        }

//        if (pseudoRandom.Next(0, 100) < 75)
//        {
//            int rand = pseudoRandom.Next(width / 2 + 1, width);
//            map[length - 1][rand] = Instantiate(Resources.Load("TrollPad"), new Vector3(length - 1, 0, rand), Quaternion.identity);
//            ((GameObject)map[length - 1][rand]).GetComponent<TrollPad>().worldX = rand;
//            ((GameObject)map[length - 1][rand]).GetComponent<TrollPad>().worldY = currentLength;
//            //((GameObject)map[length - 1, rand]).GetComponent<TrollPad>().OnPlayerStepOnPad += new EventHandler(PlayerEnterPad);
//        }
//        currentLength++;
//    }

//    private void DestroyFirstRow()
//    {
//        for (int i = 0; i < width; i++)
//        {
//            if (map[0][i] != null)
//                ((GameObject)map[0][i]).GetComponent<TrollPad>().Destroy();
//            //((GameObject)map[0, i]).GetComponent<TrollPad>().OnPlayerStepOnPad -= new EventHandler(PlayerEnterPad);
//        }

//    }

//    void PlayerEnterPad(object sender, PlayerPadEvent e)
//    {
//        Debug.Log(e.padNumber);
//    }
//}
