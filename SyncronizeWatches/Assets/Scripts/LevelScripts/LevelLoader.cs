using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelLoader : MonoBehaviour {

    [System.Serializable]
    public enum MapType
    {
        SETPIECE,
        CHUNK
    }

    [System.Serializable]
    public class TileData
    {
        public TileScript tile;
        public Color mapColor;
    }

    public MapType type;
    public Texture2D calibrationMap;

    public List<TileData> tileList = new List<TileData>();
    public List<Texture2D> mapData = new List<Texture2D>();
    public List<GameObject> processedMaps = new List<GameObject>();
    public List<TileScript> processedTiles = new List<TileScript>();
    public Vector2 mapOffset = new Vector2(0.5f, 0.5f);

    public Dictionary<Color, TileScript> tileLibrary = new Dictionary<Color, TileScript>();

    void CalibrateColors()
    {
        for(int i = 0; i < tileList.Count; i++)
        {
            tileList[i].mapColor = calibrationMap.GetPixel(i, 0);
        }
    }

    void PopulateLibrary()
    {
        for(int i = 0; i < tileList.Count; i++)
        {
            if(!tileLibrary.ContainsKey(tileList[i].mapColor))
            {
                tileLibrary.Add(tileList[i].mapColor, tileList[i].tile);
            }
        }
    }

    void ScanMap()
    {
        foreach(Texture2D map in mapData)
        {
            GameObject newMap = new GameObject(map.name);
            processedTiles.Clear();
            for(int i = 0; i < map.width; i++)
            {
                for(int j = 0; j < map.height; j++)
                {
                    GenerateTile(map, newMap, j, i);
                }
            }

            switch(type)
            {
                case MapType.CHUNK:
                    
                    GameObject baseTiles = new GameObject("Base Tiles");
                    baseTiles.transform.SetParent(newMap.transform);
                    baseTiles.AddComponent<SetPiece>();
                    SetPiece piece = baseTiles.GetComponent<SetPiece>();
                    piece.grid.AddRange(processedTiles);
                    piece.Width = map.width;
                    piece.Height = map.height;

                    newMap.AddComponent<LevelChunk>();
                    LevelChunk tempChunk = newMap.GetComponent<LevelChunk>();
                    tempChunk.baseTiles = piece;
                    Object prefab = PrefabUtility.CreatePrefab("Assets/Resources/Prefabs/LevelPrefabs/LevelChunks/" + map.name + ".prefab", newMap);
                    //AssetDatabase.CreateAsset(newMap, "Assets/Resources/Prefabs/LevelPrefabs/LevelChunks/" + map.name);
                    break;
                case MapType.SETPIECE:
                    newMap.AddComponent<SetPiece>();
                    SetPiece tempPiece = newMap.GetComponent<SetPiece>();
                    tempPiece.grid.AddRange(processedTiles);
                    tempPiece.Width = map.width;
                    tempPiece.Height = map.height;
                    AssetDatabase.CreateAsset(newMap, "Assets/Resources/Prefabs/LevelPrefabs/SetPieces/" + map.name);
                    break;
            }
        }
    }

    void GenerateTile(Texture2D map, GameObject parent, int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);
        Debug.Log(pixelColor);

        if(tileLibrary.ContainsKey(pixelColor))
        {
            GameObject obj = Instantiate(tileLibrary[pixelColor].gameObject, parent.transform);
            Vector2 tilePos;
            tilePos.x = mapOffset.x + (x * GlobalDataContainer.tileWidth);
            tilePos.y = mapOffset.y + (y * GlobalDataContainer.tileHeight);
            obj.transform.localPosition = tilePos;
            processedTiles.Add(obj.GetComponent<TileScript>());
        }
        else
        {
            processedTiles.Add(null);
        }
    }
	// Use this for initialization
	void Start () {
        CalibrateColors();
        PopulateLibrary();
        ScanMap();
	}
}
