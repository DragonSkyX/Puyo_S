using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Board : MonoBehaviour {

    bool CG; 

	List <GameObject>  Puyos = new List<GameObject>();
    public static int w = 28;
    public static int h = 20;
    public GameObject[,] grid = new GameObject[w, h];
    GameObject Particle;
    GameControl GC;

    PuyoSpawn PS;
    int CCount = 0;
    void Awake () {
        PS = GameObject.Find("PuyoSpawn").GetComponent<PuyoSpawn>();

    }

    void CheckBoard() {
        Puyos.AddRange(GameObject.FindGameObjectsWithTag("Puyo"));
        for (int i = 0; i < Puyos.Count; i++) {
            if (Puyos[i].GetComponent<Puyo_TYPE>().GetCollide()) {
                CCount += 1;
            }



        }
    }

    private void Start()
    {
        PS.SpawnPuyo();
        GC = GameObject.Find("PuyoSpawn").GetComponent<GameControl>();
        Particle = Resources.Load<GameObject>("Particle/Particle");
    }

    public static Vector2 roundVec2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    public IEnumerator CompareGrid() {
        UpdateGrid();
        yield return new WaitUntil(() => CG == true);

        for (int y = 0; y < h - 4; y++) { 
            for (int x = 0; x < w - 4; x++)
            {

                if (grid[x, y] != null && grid[x + 2, y] != null && grid[x + 4, y] != null)
                {
                    if (grid[x, y].GetComponent<Puyo_TYPE>().P == grid[x + 2, y].GetComponent<Puyo_TYPE>().P && grid[x + 4, y].GetComponent<Puyo_TYPE>().P == grid[x, y].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x + 2, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x + 4, y].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x+2, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x+4, y, transform.position.z), transform.rotation);
                        GC.Score += 30;

                    }
                }

                else if (grid[x, y] != null && grid[x, y + 2] != null && grid[x, y + 4] != null)
                {



                    if (grid[x, y].GetComponent<Puyo_TYPE>().P == grid[x, y + 2].GetComponent<Puyo_TYPE>().P && grid[x, y + 4].GetComponent<Puyo_TYPE>().P == grid[x, y+2].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x, y + 4].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x, y+2, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x, y+4, transform.position.z), transform.rotation);
                        GC.Score+= 30;

                    }
                }

                else if (grid[x, y] != null && grid[x + 2, y] != null && grid[x, y + 2] != null)
                {
                    if (grid[x, y].GetComponent<Puyo_TYPE>().P == grid[x, y + 2].GetComponent<Puyo_TYPE>().P && grid[x, y].GetComponent<Puyo_TYPE>().P == grid[x + 2, y].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x + 2, y].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x+2, y + 2, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x+2, y, transform.position.z), transform.rotation);
                        GC.Score += 30;



                    }
                }
                else if (grid[x, y] != null && grid[x + 2, y + 2] != null && grid[x, y + 2] != null)
                {
                    if (grid[x, y + 2].GetComponent<Puyo_TYPE>().P == grid[x + 2, y + 2].GetComponent<Puyo_TYPE>().P && grid[x, y + 2].GetComponent<Puyo_TYPE>().P == grid[x, y].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x + 2, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x + 2, y + 2, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x + 2, y+2, transform.position.z), transform.rotation);
                        GC.Score += 30;


                    }
                }

                else if (x > 2 && grid[x, y] != null && grid[x - 2, y + 2] != null && grid[x, y + 2] != null)
                {

                    if ( grid[x, y + 2].GetComponent<Puyo_TYPE>().P == grid[x - 2, y + 2].GetComponent<Puyo_TYPE>().P && grid[x, y + 2].GetComponent<Puyo_TYPE>().P == grid[x, y].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x - 2, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x, y + 2, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x - 2, y, transform.position.z), transform.rotation);
                        GC.Score += 30;

                    }
                }

                else if (x > 2&&grid[x, y] != null && grid[x - 2, y] != null && grid[x-2, y + 2] != null)
                {
                    if (grid[x, y].GetComponent<Puyo_TYPE>().P == grid[x-2, y].GetComponent<Puyo_TYPE>().P && grid[x-2, y+2].GetComponent<Puyo_TYPE>().P == grid[x-2, y].GetComponent<Puyo_TYPE>().P)
                    {
                        grid[x, y].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x-2, y + 2].GetComponent<Puyo_TYPE>().PDestroy();
                        grid[x - 2, y].GetComponent<Puyo_TYPE>().PDestroy();
                        Instantiate(Particle, new Vector3(x, y, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x, y + 2, transform.position.z), transform.rotation);
                        Instantiate(Particle, new Vector3(x - 2, y, transform.position.z), transform.rotation);
                        GC.Score += 30;



                    }
                }
            }
        }



             



    }


    

    public void UpdateGrid()
    {
        CG = false;
        Puyos.Clear();
        Puyos.AddRange(GameObject.FindGameObjectsWithTag("Puyo"));

        for (int y = 0; y < h; y++) {
            for (int x = 0; x < w; x++)
            {
                Vector2 Pos = new Vector2(x, y);

                for (int i = 0; i < Puyos.Count; i++)
                {
                    if (Pos == roundVec2(Puyos[i].transform.position))
                    {
                        grid[x, y] = Puyos[i];

                    }
                }
            }


        }
        CG = true;

    }


    void Update () {




    }
}
