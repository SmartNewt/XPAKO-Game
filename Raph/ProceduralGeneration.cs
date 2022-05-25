using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    [SerializeField] int width, height;
    [SerializeField] Tilemap Tilemap, Collidemap;
    [SerializeField] Tile dirt, grass, stone, water, brick;
    [Range(0,100)]
    [SerializeField] float smoothness;
    [SerializeField] float seed;
    [Range(0,1)]
    [SerializeField] float waterLevel, grassLevel, dirtLevel;

    public float scale = .1f;
    public bool maison = false;

    Cell[,] grid;

    void Start()
    {
        seed = Random.Range(-1000000, 1000000);
        Generation();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            seed = Random.Range(-1000000, 1000000);
            maison = false;
            Generation();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Tilemap.ClearAllTiles();
            Collidemap.ClearAllTiles();
        }
    }
    void Generation()
    {
        float[,] noiseMap = new float[width, height];
        (float xOffset, float yOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                float noiseValue = Mathf.PerlinNoise(x * scale + xOffset, y * scale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }

        grid = new Cell[width, height];
        for(int y = 0; y < height; y++) {
            for(int x = 0; x < width; x++) {
                float noiseValue = noiseMap[x, y];
                bool isGrass = noiseValue < grassLevel;
                bool isDirt = noiseValue < dirtLevel;
                bool isWater = noiseValue < waterLevel;
                Cell cell = new Cell(isGrass, isDirt, isWater);
                grid[x, y] = cell;
            }
        }

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = grid[x, y];
                
                if(cell.isWater)
                {
                    Collidemap.SetTile(new Vector3Int(x, y, 0), water);
                }
                else if (cell.isGrass)
                {
                    //spawnObj(grass, x, y);
                    Tilemap.SetTile(new Vector3Int(x, y, 0), grass);
                }
                else if(cell.isDirt)
                {
                    // spawnObj(dirt, x, y);
                    Tilemap.SetTile(new Vector3Int(x, y, 0), dirt);
                }
                else
                {
                    Tilemap.SetTile(new Vector3Int(x, y, 0), stone);
                }
            }
        }
        while (!maison)
        {
            int buildable = 0;
            int randx = Random.Range(0, width);
            int randy = Random.Range(0, height);
            if(Tilemap.GetTile(new Vector3Int(randx, randy, 0)) == grass)
            {              
                for(int x = 0; x < 3; x++)
                {
                    for(int y = 0; y < 3; y++)
                    {
                        if(Tilemap.GetTile(new Vector3Int(randx + x, randy + y, 0)) == grass)
                        {
                            buildable = buildable + 1; 
                        }
                    }  
                }
            }
            if (buildable == 9)
            {
                for(int x = 0; x < 3; x++)
                {
                    for(int y = 0; y < 3; y++)
                    {
                        Tilemap.SetTile(new Vector3Int(randx + x, randy + y, 0), null);
                        Collidemap.SetTile(new Vector3Int(randx + x, randy + y, 0), brick);
                    }
                }

                maison = true;
            }
        }
        
    }
}
