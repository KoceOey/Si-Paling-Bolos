using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public GameObject[] powerUpPrefabs = new GameObject[2];
    public static int tilePassed = 0;
    public int powerUpSpawnRate = 5;
    public Transform playerTransform;
    private List<GameObject> activePowerUp =  new List<GameObject>();
    public static float zSpawn = -39.1664f;
    public float[] xSpawn = new float[3];
    public float tileLength = 30;
    public int numberOfTiles = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z -35 > zSpawn-(numberOfTiles*tileLength)){
            zSpawn += tileLength;
            tilePassed++;
            if(tilePassed == powerUpSpawnRate){
                tilePassed = 0;
                int random = Random.Range(0,100);
                if(random % 2 == 0){
                    spawnAnggurMerah();
                }else{
                    spawnSepatuSuper();
                }
                if(activePowerUp.Count >= 5){
                    deletePowerUp();
                }
            }
        }
    }

    public void spawnSepatuSuper(){
        xSpawn = new float[3] {-1.5f,1f,3.5f};
        int randomLane = Random.Range(0,xSpawn.Length);
        GameObject go = Instantiate(powerUpPrefabs[1], transform.forward * zSpawn + transform.right * xSpawn[randomLane] + transform.up, transform.rotation);
        activePowerUp.Add(go);
    }

    public void spawnAnggurMerah(){
        xSpawn = new float[3] {-2.4f,-0.1f,2.6f};
        int randomLane = Random.Range(0,xSpawn.Length);
        GameObject go = Instantiate(powerUpPrefabs[0], transform.forward * zSpawn + transform.right * xSpawn[randomLane] + transform.up, transform.rotation);
        activePowerUp.Add(go);
    }

    public void deletePowerUp(){
        Destroy(activePowerUp[0]);
        activePowerUp.RemoveAt(0);
    }
}
