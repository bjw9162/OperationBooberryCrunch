using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    [System.Serializable]
    public class chunkSlot
    {
        public LevelChunk chunk;
        public bool occupied = false;
    }

    [System.Serializable]
    public class tileSlot
    {
        public TileScript tile;
        public bool occupied = false;
    }

    [System.Serializable]
    public class SpawnPoint
    {
        public Vector2 position;
        bool player = false;

        public SpawnPoint(TileScript t)
        {
            position = t.gameObject.transform.position;
            player = t.type == TileScript.TileType.PLAYERSPAWN;
        }
    }

    public LevelManager lMan;

    public int chunkRows;
    public int chunkColumns;

    public int tileRows;
    public int tileColumns;

    public int minChunkCount = 5;
    public int maxChunkCount = 10;

    int currentChunkCount;

    public List<chunkSlot> chunkGrid = new List<chunkSlot>();
    public List<tileSlot> tileGrid = new List<tileSlot>();

    public List<LevelChunkCluster> clusters = new List<LevelChunkCluster>();
    public List<LevelChunkCluster> entranceChunks = new List<LevelChunkCluster>();

    public List<SpawnPoint> spawns = new List<SpawnPoint>();

    public void Init()
    {
        tileColumns = chunkColumns * GlobalDataContainer.chunkWidth;
        tileRows = chunkRows * GlobalDataContainer.chunkHeight;

        for (int i = 0; i < chunkColumns * chunkRows; i++)
        {
            chunkGrid.Add(new chunkSlot());
        }


        GenerateLevel();
        
    }

    public void GenerateLevel()
    {
        currentChunkCount = 0;
        Vector2 currentGridPos = new Vector2(0, 0);

        //--------------------------------------
        //TODO: Actual generation code goes here
        //--------------------------------------

        AddCluster(0, 0, clusters[0]);
        AddCluster(1, 0, clusters[0]);
        AddCluster(0, 1, clusters[0]);

        ConnectChunks();
        PopulateTiles();
    }

    public bool AddCluster(int x, int y, LevelChunkCluster c)
    {
        if (chunkGrid[(y * chunkColumns) + x].occupied)
        {
            return false;
        }
            //make sure the spot in question isn't occupied
        for(int i = 0; i < c.width; i++)
        {
            for(int j = 0; j < c.height; j++)
            {
                if(x+i >= chunkColumns || y+j >= chunkRows || chunkGrid[((y+j) * chunkColumns) + (x+i)].occupied)
                {
                    return false;
                }
            }
        }

        GameObject obj = Instantiate(c.gameObject);
        LevelChunkCluster newCluster = obj.GetComponent<LevelChunkCluster>();


        for (int i = 0; i < c.width; i++)
        {
            for (int j = 0; j < c.height; j++)
            {
                if(newCluster.grid[i + (j * c.width)] != null)
                {
                    newCluster.grid[i + (j * c.width)].ChunkPosX = x + i;
                    newCluster.grid[i + (j * c.width)].ChunkPosY = y + j;
                    chunkGrid[((y + j) * chunkColumns) + (x + i)].chunk = newCluster.grid[i + (j * c.width)];
                    chunkGrid[((y + j) * chunkColumns) + (x + i)].occupied = true;
                    newCluster.grid[i + (j * c.width)].GenerateSetPieces(lMan);
                }
            }
        }

        return true;
    }

    public void ConnectChunks()
    {
        for(int i= 0; i < chunkGrid.Count; i++)
        {
            if (!chunkGrid[i].occupied)
                continue;
                
            if(chunkGrid[i].chunk.connectionsPresent[0] && chunkGrid[i].chunk.connections[0] == null)
            {
                if(i % chunkColumns != chunkColumns-1 && chunkGrid[i + 1].occupied && chunkGrid[i + 1].chunk.connectionsPresent[2])
                {
                    chunkGrid[i].chunk.connections[0] = chunkGrid[i + 1].chunk;
                    chunkGrid[i + 1].chunk.connections[2] = chunkGrid[i].chunk;
                }
            }

            if (chunkGrid[i].chunk.connectionsPresent[1] && chunkGrid[i].chunk.connections[1] == null)
            {
                if (i / chunkColumns != chunkRows - 1 && chunkGrid[i + chunkColumns].occupied && chunkGrid[i + chunkColumns].chunk.connectionsPresent[3])
                {
                    chunkGrid[i].chunk.connections[1] = chunkGrid[i + chunkColumns].chunk;
                    chunkGrid[i + chunkColumns].chunk.connections[3] = chunkGrid[i].chunk;
                }
            }
        }
    }

    public void PopulateTiles()
    {
        tileGrid.Clear();

        for (int i = 0; i < tileColumns * tileRows; i++)
        {
            tileGrid.Add(new tileSlot());
        }

        for(int i = 0; i < chunkGrid.Count; i++)
        {
            if(chunkGrid[i].occupied)
            {
                for(int j = 0; j < chunkGrid[i].chunk.chunkTiles.Count; j++)
                {
                    int chunkOffset = i * GlobalDataContainer.chunkWidth;
                    int tileIndex = chunkOffset + ((j / GlobalDataContainer.chunkWidth) * tileColumns) + (j % GlobalDataContainer.chunkWidth);
                    tileGrid[tileIndex].tile = chunkGrid[i].chunk.chunkTiles[j];
                    tileGrid[tileIndex].occupied = true;

                    if(chunkGrid[i].chunk.chunkTiles[j].type == TileScript.TileType.PLAYERSPAWN)
                    {
                        spawns.Add(new SpawnPoint(chunkGrid[i].chunk.chunkTiles[j]));
                    }
                }
            }
        }
    }
}
