using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puyo_SMovement : MonoBehaviour {

    public static int angle = 0;
    Board B;
    Vector2 Rotate;
    public Rigidbody2D R;
    bool CanDie = false;

	void Start () {

        B = GameObject.Find("PuyoSpawn").GetComponent<Board>();
        R = GetComponent<Rigidbody2D>();


    }
    public void Rot(float X, float Y) {


        Rotate = new Vector2(Mathf.Sin(angle) * 3, (Mathf.Cos(angle) * 3));
        transform.position = new Vector2(X + Rotate.x, Y + Rotate.y);
        angle += 90;
        if (angle > 360)
            angle = 0;

    }

    private void OnCollisionEnter2D(Collision2D C)
    {



    }

    // Update is called once per frame
    void Update () {
		
	}
}
