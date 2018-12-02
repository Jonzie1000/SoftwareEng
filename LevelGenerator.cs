using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour {

    public GameObject[] tiles;
    public GameObject[] monsters;
    public GameObject wall;
    public List <Vector3> createdTiles;
    public List<Vector3> createdMonsters;
    public int tileAmount;
    public int tileSize;
    public float waitTime;

    public float chanceUp;
    public float changeRight;
    public float chanceDown;

    //Wall Generation
    public float minY = 99999999;
    public float maxY = 0;
    public float minX = 99999999;
    public float maxX = 0;
    public float xAmount;
    public float yAmount;
    public float extraWallX;
    public float extraWallY;



	void Start () {

        StartCoroutine(GenerateLevel());
        
	}
	
	IEnumerator GenerateLevel()
    {
        for(int i = 0; i < tileAmount-1; i++)
        {

            float dir = Random.Range(0f, 1f);
            int tile = Random.Range(0, tiles.Length-1);

            CreateTile(tile);
            CallMoveGen(dir);
        }
        BuildDoor();

        yield return 0;
    }

    void CallMoveGen(float ranDir)
    {
        if (ranDir < chanceUp)
        {
            MoveGen(0);
        }else if (ranDir < changeRight)
        {
            MoveGen(1);
        }else if (ranDir < chanceDown)
        {
            MoveGen(2);
        }
        else
        {
            MoveGen(3);
        }
    }

    void MoveGen(int dir)
    {
        switch (dir)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, transform.position.y + tileSize, 0);
                break;

            case 1:
                transform.position = new Vector3(transform.position.x + tileSize, transform.position.y, 0);

                break;

            case 2:
                transform.position = new Vector3(transform.position.x, transform.position.y - tileSize, 0);

                break;

            case 3:
                transform.position = new Vector3(transform.position.x - tileSize, transform.position.y, 0);

                break;
        }
    }

    void CreateTile(int tileIndex)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject monster;
            GameObject tileObject;

            int rand = Random.Range(0, 10);

            tileObject = Instantiate(tiles[tileIndex], transform.position, transform.rotation) as GameObject;
            if (rand == 0)
            {
                monster = Instantiate(monsters[rand], transform.position, transform.rotation) as GameObject;
                createdMonsters.Add(monster.transform.position);
            }
            createdTiles.Add(tileObject.transform.position);


        }
        else
        {
            tileAmount++;
        }
    }

    void BuildDoor()
    {
        for (int i = tileAmount-1; i < tileAmount; i++)
        {
            float dir = Random.Range(0f, 1f);
            int tile = 3;

            CreateLastTile(tile);
            CallMoveGen(dir);
        }
        Finish();

    }

    void CreateLastTile(int tile)
    {
        if (!createdTiles.Contains(transform.position))
        {
            GameObject tileObject;

            tileObject = Instantiate(tiles[tile], transform.position, transform.rotation) as GameObject;
            createdTiles.Add(tileObject.transform.position);

        }
        else
        {
            tileAmount++;
        }
        

    }

    void Finish()
    {
        CreateWallValues();
        CreateWalls();
    }

    void CreateWallValues()
    {
        for(int i = 0; i < createdTiles.Count; i++)
        {
            if(createdTiles[i].y < minY)
            {
                minY = createdTiles[i].y;
            }
            if (createdTiles[i].y > maxY)
            {
                maxY = createdTiles[i].y;
            }
            if (createdTiles[i].x < minX)
            {
                minX = createdTiles[i].x;
            }
            if (createdTiles[i].x > maxX)
            {
                maxX = createdTiles[i].x;
            }

            xAmount = ((maxX - minX) / tileSize) + extraWallX;
            yAmount = ((maxY - minY) / tileSize) + extraWallY;
        }
    }

    void CreateWalls()
    {
        for(int x = 0; x < xAmount; x++)
        {
            for(int y = 0; y< yAmount; y++)
            {
                if(!createdTiles.Contains(new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize))))
                {
                    Instantiate(wall, new Vector3((minX - (extraWallX * tileSize) / 2) + (x * tileSize), (minY - (extraWallY * tileSize) / 2) + (y * tileSize)), transform.rotation);
                }
            }
        }
    }
}
