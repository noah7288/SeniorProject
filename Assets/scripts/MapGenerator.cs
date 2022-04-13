using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


//https://www.red-gate.com/simple-talk/development/dotnet-development/procedural-generation-unity-c/

public class MapGenerator : MonoBehaviour
{
    public GameObject[] tiles;
    public int columns;
    public int rows;
    public int maxBlue = 100;
    public int maxRed = 100;
    public int maxYellow = 100;
    public int maxGreen = 5;
    public int howManyWhite = 30;
    private int whiteTileCount;
    private int greenTileCount;
    private int redTileCount;
    private int blueTileCount;
    private int yellowTileCount;
    private int tileToGenerate = 0;
    private int resetHowManyWhite;

    public GameObject enemy;

    public int trapCount;



    void Start()
    {
        resetHowManyWhite = howManyWhite;
        LoadMap();
        trapCount = 0;
        
    }

    
    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    //enemy = GameObject.FindWithTag("Enemy");
        //    //foreach (GameObject enemy in enemy)
        //    //    Destroy(enemy.gameObject);
        //    //Destroy(enemy);
        //    foreach (Transform child in transform)
        //        Destroy(child.gameObject);
        //    LoadMap();
        //    AstarPath.active.Scan();
        //}
    }

    void LoadMap()
    {
        greenTileCount = 0;
        whiteTileCount = 0;
        redTileCount = 0;
        blueTileCount = 0;
        yellowTileCount = 0;
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                //if (x >= 0 && x < 3 && y >= 0 && y < 3)
                //{
                //    tileToGenerate = 1;
                //    CheckTile(tileToGenerate);
                //    GameObject obj;
                //    obj = Instantiate(tiles[tileToGenerate], new Vector3(x*10, y*10, 0), Quaternion.identity);
                //    obj.transform.parent = transform;
                //}
                //else if (x == rows - 1 && y == columns - 1)
                //{
                //    tileToGenerate = 0;
                //    greenTileCount++;
                //    GameObject obj;
                //    obj = Instantiate(tiles[tileToGenerate], new Vector3(x*10, y*10, 0), Quaternion.identity);
                //    obj.transform.parent = transform;
                //}
                //else if (x >= rows - 3 && y >= columns - 3)
                //{
                //    tileToGenerate = 1;
                //    CheckTile(tileToGenerate);
                //    GameObject obj;
                //    obj = Instantiate(tiles[tileToGenerate], new Vector3(x * 10, y * 10, 0), Quaternion.identity);
                //    obj.transform.parent = transform;
                //}
                //else
                //{
                    Vector3 pos = new Vector3(x, 0, y);
                    tileToGenerate = Random.Range(0, 5);
                    CheckTile(tileToGenerate);
                    GameObject obj;
                if (tileToGenerate == 3) 
                {
                    trapCount++;
                }
                if(tileToGenerate == 3 & trapCount >= GameStats.Instance.trapMax)
                {
                    tileToGenerate = 1;
                }
                    obj = Instantiate(tiles[tileToGenerate], new Vector3(x * 10, y * 10, 0), Quaternion.identity);
                    obj.transform.parent = transform;
                
                //}
            }
        }
        //Debug.Log("white tiles = " + whiteTileCount);
        //Debug.Log("red tiles = " + redTileCount);
        //Debug.Log("green tiles = " + greenTileCount);
        //Debug.Log("blue tiles = " + blueTileCount);
        //Debug.Log("yellow tiles = " + yellowTileCount);

        AstarPath.active.Scan();
    }

    void CheckTile(int randomTile)
    {
        switch (randomTile)
        {
            case 0:
                if (greenTileCount >= maxGreen - 1)
                {
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else
                {
                    if (howManyWhite <= 0)
                    {
                        greenTileCount++;
                        howManyWhite = resetHowManyWhite;
                        break;
                    }
                    else
                    {
                        tileToGenerate = 1;
                        whiteTileCount++;
                        howManyWhite--;
                        break;
                    }
                }
            case 1:
                whiteTileCount++;
                howManyWhite--;
                break;
            case 2:
                if (redTileCount >= maxRed)
                {
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else
                {
                    redTileCount++;
                    break;
                }
            case 3:
                if (blueTileCount >= maxBlue)
                {
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else
                {
                    blueTileCount++;
                    break;
                }
            case 4:
                if (yellowTileCount >= maxYellow)
                {
                    tileToGenerate = 1;
                    whiteTileCount++;
                    howManyWhite--;
                    break;
                }
                else
                {
                    yellowTileCount++;
                    break;
                }
            default:
                whiteTileCount++;
                howManyWhite--;
                break;
        }
    }



}
