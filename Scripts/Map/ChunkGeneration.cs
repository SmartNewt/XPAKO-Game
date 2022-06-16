using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChunkGeneration : MonoBehaviour
{
    [SerializeField]
    int width,
        height;

    [SerializeField]
    Tilemap Objectmap,
        Tilemap,
        Collidemap;

    [SerializeField]
    Tile dirt,
        grass,
        stone,
        snow,
        deepWater,
        shallowWater,
        brick,
        obstacle;

    [Range(0, 100)]
    [SerializeField]
    float smoothness;

    [SerializeField]
    float seed;

    [Range(0, 1)]
    [SerializeField]
    float deepWaterLevel,
        shallowWaterLevel,
        grassLevel,
        dirtLevel,
        stoneLevel;

    [SerializeField]
    int maxObjects;

    public float scale = .1f;
    public int numberObjects;
    public Vector3Int location;

    Cell[,] grid;

    void Start()
    {
        seed = Random.Range(-1000000, 1000000);
        Generation();
        BuildStruct(4, 3, brick, grass);
        BuildObject(obstacle, grass);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            seed = Random.Range(-1000000, 1000000);
            Generation();
            BuildStruct(4, 3, brick, grass);
            numberObjects = 0;
            BuildObject(obstacle, grass);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Tilemap.ClearAllTiles();
            Collidemap.ClearAllTiles();
            Objectmap.ClearAllTiles();
        }
        if (numberObjects < maxObjects)
        {
            BuildObject(obstacle, grass);
        }
        // if (Input.GetMouseButtonDown(1))
        // {
        //     Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //     location = Objectmap.WorldToCell(mp);
        //     location.z = -5;
        //     if (Objectmap.GetTile(location))
        //     {
        //         Debug.Log(location);
        //         Debug.Log(Objectmap.GetTile(location));
        //         Objectmap.SetTile(location, null);
        //     }
        //     else
        //     {
        //         Debug.Log(location);
        //         Debug.Log("no tile");
        //     }
        // }

        // GameObject Chunk = GameObject.Find("Chunk");
        // GameObject player = GameObject.Find("MainChar");
        // Vector3 position = player.transform.position;
        // Debug.Log(position);
        // if (player.transform.position.x % 120 == 0)
        // {
        //     GameObject duplicate = Instantiate(Chunk, new Vector3(position.x, 0, 0), new Quaternion(0,0,0,0));
        // }
        // else if (player.transform.position.y % 120 == 0)
        // {
        //     GameObject duplicate = Instantiate(Chunk, new Vector3(0, position.y, 0), new Quaternion(0,0,0,0));
        // }
    }

    void Generation()
    {
        float[,] noiseMap = new float[width, height];
        (float xOffset, float yOffset) = (
            Random.Range(-10000f, 10000f),
            Random.Range(-10000f, 10000f)
        );
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }

        float[,] falloffMap = new float[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float xv = x / (float)width * 2 - 1;
                float yv = y / (float)height * 2 - 1;
                float v = Mathf.Max(Mathf.Abs(xv), Mathf.Abs(yv));
                falloffMap[x, y] =
                    Mathf.Pow(v, 9f) / (Mathf.Pow(v, 3f) + Mathf.Pow(3.2f - 3.2f * v, 4f));
            }
        }

        grid = new Cell[width, height];
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float noiseValue = noiseMap[x, y];
                noiseValue -= falloffMap[x, y];
                bool isGrass = noiseValue < grassLevel;
                bool isDirt = noiseValue < dirtLevel;
                bool isShallowWater = noiseValue < shallowWaterLevel;
                bool isDeepWater = noiseValue < deepWaterLevel;
                bool isStone = noiseValue < stoneLevel;
                Cell cell = new Cell(isGrass, isDirt, isShallowWater, isDeepWater, isStone);
                grid[x, y] = cell;
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = grid[x, y];

                if (cell.isDeepWater)
                {
                    Collidemap.SetTile(new Vector3Int(x, y, -5), deepWater);
                }
                else if (cell.isShallowWater)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, -5), shallowWater);
                }
                else if (cell.isGrass)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, -5), grass);
                }
                else if (cell.isDirt)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, -5), dirt);
                }
                else if (cell.isStone)
                {
                    Tilemap.SetTile(new Vector3Int(x, y, -5), stone);
                }
                else
                {
                    Tilemap.SetTile(new Vector3Int(x, y, -5), snow);
                }
            }
        }
    }

    void BuildStruct(int largeur, int hauteur, Tile material, Tile support)
    {
        int buildable = 0;
        int surface = largeur * hauteur;
        while (buildable < surface)
        {
            buildable = 0;
            int randx = Random.Range(0, width);
            int randy = Random.Range(0, height);
            if (Tilemap.GetTile(new Vector3Int(randx, randy, -5)) == support)
            {
                for (int x = 0; x < largeur; x++)
                {
                    for (int y = 0; y < hauteur; y++)
                    {
                        if (Tilemap.GetTile(new Vector3Int(randx + x, randy + y, -5)) == support)
                        {
                            buildable = buildable + 1;
                        }
                    }
                }
            }
            if (buildable == surface)
            {
                for (int x = 0; x < largeur; x++)
                {
                    for (int y = 0; y < hauteur; y++)
                    {
                        Tilemap.SetTile(new Vector3Int(randx + x, randy + y, -5), null);
                        Collidemap.SetTile(new Vector3Int(randx + x, randy + y, -5), material);
                    }
                }
            }
        }
    }

    public void BuildObject(Tile material, Tile support)
    {
        while (numberObjects < maxObjects)
        {
            int clear = 0;
            int randx = Random.Range(0, width);
            int randy = Random.Range(0, height);
            if (Tilemap.GetTile(new Vector3Int(randx, randy, -5)) == support)
            {
                for (int x = 0; x < 3; x++)
                {
                    for (int y = 0; y < 3; y++)
                    {
                        if (Tilemap.GetTile(new Vector3Int(randx + x, randy + y, -5)) == support)
                        {
                            clear = clear + 1;
                        }
                    }
                }
                if (clear == 9)
                {
                    numberObjects += 1;
                    Objectmap.SetTile(new Vector3Int(randx, randy, -5), material);
                }
            }
        }
    }
}
