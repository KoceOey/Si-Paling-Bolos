using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject startingTiles;
    public GameObject[] tilePrefabs;
    public float zSpawn = -41.1664f;
    public static float tileLength = 30;
    public static int numberOfTiles = 5;
    public Transform playerTransform;
    private List<GameObject> activeTiles =  new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numberOfTiles; i++){
            if(i == 0){
                SpawnTile(startingTiles);
            }else{
                SpawnTile(tilePrefabs[Random.Range(0,tilePrefabs.Length)]);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -35 > zSpawn-(numberOfTiles*tileLength))
        {
            SpawnTile(tilePrefabs[Random.Range(0,tilePrefabs.Length)]);
            DeleteTile();
        }
    }

    public void SpawnTile(GameObject tile)
    {
        GameObject go = Instantiate(tile, transform.forward * zSpawn + transform.right * -17.35553f + transform.up * -13.39811f , transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    public void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
