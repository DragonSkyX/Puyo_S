using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PuyoSpawn : MonoBehaviour
{
   List<GameObject> PuyoPuyoS = new List<GameObject>();
    List<GameObject> PuyoPuyoH = new List<GameObject>();
    int spawnRandom=0;
    int PuyoCount=0;
    GameControl GC;
    public int Limit = 5;

    void Awake()
    {
        PuyoPuyoS.AddRange(Resources.LoadAll<GameObject>("Prefab/SimplePuyo"));
        PuyoPuyoH.AddRange(Resources.LoadAll<GameObject>("Prefab/HardPuyo"));
        PuyoPuyoH.AddRange(Resources.LoadAll<GameObject>("Prefab/SimplePuyo"));
        GC = GameObject.Find("PuyoSpawn").GetComponent<GameControl>();

    }

    private void Start()
    {
        InvokeRepeating("SpawnPuyo", 3, 3);
    }

    public  void SpawnPuyo() {
        if (GC.Level < 5) { 
        spawnRandom= Random.Range(0, PuyoPuyoS.Count);
        Instantiate(PuyoPuyoS[spawnRandom], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
        PuyoCount += 1;
        }
        if (GC.Level >= 5) {
                spawnRandom = Random.Range(0, PuyoPuyoH.Count);
                Instantiate(PuyoPuyoH[spawnRandom], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                PuyoCount += 1;
        

        }

        if (PuyoCount > Limit) {
            Limit += 3;
            PuyoCount = 0;
            GC.Level += 1;
        }

    }
    void Update()
    {

    }
}
