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
        
    }

    void LoadMap()
    {
        
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
               
                    Vector3 pos = new Vector3(x, 0, y);
                    tileToGenerate = Random.Range(0, 5);
                   
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
                
                
            }
        }
        

        AstarPath.active.Scan();
    }

    



}
