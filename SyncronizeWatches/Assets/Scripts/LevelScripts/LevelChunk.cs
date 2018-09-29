using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChunk : MonoBehaviour {

    [System.Serializable]
    public class LevelSlot
    {
        public int xPos;
        public int yPos;
        public int slotWidth;
        public int slotHeight;
        public bool filled = false;
        public List<SetPiece> possiblePieces = new List<SetPiece>();
    }

    private int chunkPosX;
    public int ChunkPosX{ get { return chunkPosX; } set { chunkPosX = value; } }

    private int chunkPosY;
    public int ChunkPosY { get { return chunkPosY; } set { chunkPosY = value; } }

    public List<SetPiece> setPieces = new List<SetPiece>();
    public List<LevelSlot> slots = new List<LevelSlot>();

    public bool preconnected;
    public bool[] connectionsPresent = new bool[4];
    public LevelChunk[] connections = new LevelChunk[4];



    public void GenerateSetPieces(LevelManager lMan)
    {
        transform.position = new Vector3((chunkPosX * GlobalDataContainer.chunkWidth * GlobalDataContainer.tileWidth), (chunkPosY * GlobalDataContainer.chunkHeight * GlobalDataContainer.tileHeight), 0);
        for(int i = 0; i < slots.Count; i++)
        {
            GameObject obj = Instantiate(slots[i].possiblePieces[Random.Range(0, slots[i].possiblePieces.Count)].gameObject);
            obj.transform.localPosition = new Vector3(slots[i].xPos * GlobalDataContainer.tileWidth, slots[i].yPos * GlobalDataContainer.tileHeight, 0);
            SetPiece newSet = obj.GetComponent<SetPiece>();
            setPieces.Add(newSet);
        }
    }
}
