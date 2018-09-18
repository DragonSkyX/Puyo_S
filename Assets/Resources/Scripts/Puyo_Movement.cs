using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PuyoState {Grounded,Free, Rotate };

public class Puyo_Movement : MonoBehaviour {

    public int Speed = 10;
    Rigidbody2D Puyo;
    public PuyoState PS;
    GameControl GC;
    Board B;


    void Awake()
    {
        PS = PuyoState.Free;
    }
	void Start () {
        Puyo = GetComponent<Rigidbody2D>();
        B = GameObject.Find("PuyoSpawn").GetComponent<Board>();
        GC = GameObject.Find("PuyoSpawn").GetComponent<GameControl>();
        Puyo.gravityScale += (GC.Level / 10);
        //SP = transform.GetComponentInChildren(typeof(Puyo_SMovement)) as Puyo_SMovement;

    }

    void Movement() {
        if (Input.GetAxisRaw("Horizontal") !=0 && PS != PuyoState.Grounded) {

            transform.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * Speed *3*Time.deltaTime,0));
            



        }




    }

  /*  void Rotate() {

        if(PS!=PuyoState.Grounded && Input.GetButtonDown("Fire1")){
            SP.Rot(transform.position.x, transform.position.y);


        }

    }*/

    private void OnCollisionEnter2D(Collision2D C)
    {


        if (C.gameObject.tag == "Ground")
        {
            PS = PuyoState.Grounded;
            Puyo.isKinematic = false;
            StartCoroutine(B.CompareGrid());

        }

        if (C.gameObject.tag == "Puyo" && C.gameObject.GetComponent<Puyo_Movement>().PS == PuyoState.Grounded)
        {
            PS = PuyoState.Grounded;
            StartCoroutine(B.CompareGrid());

        }


    }

    void Update () {
        Movement();
        //Rotate();
      
		
	}
}
