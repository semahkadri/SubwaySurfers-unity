using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileManager : MonoBehaviour
{   
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float TileLength = 30;
    public int numberOfTiles = 6;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;
    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++)
        { if (i==0)
                SpawnTile(0);
        else
            SpawnTile(Random.Range(0,tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z-35>zSpawn-(numberOfTiles*TileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
        
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex],transform.forward*zSpawn,transform.rotation);
        activeTiles.Add(go);
        zSpawn += TileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
