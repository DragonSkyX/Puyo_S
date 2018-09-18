using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PType {Yellow, Green, Blue, DarkBlue, Purple, Orange };
public class Puyo_TYPE : MonoBehaviour {

    bool Collide;
    public PType P;
	void Start () {
        Collide = false;
	}

    private void OnCollisionEnter2D(Collision2D C)
    {
        if (C.gameObject.tag == "Puyo" && C.gameObject.GetComponent<Puyo_TYPE>().P == P)
        {
            Collide = true;

        }
    }

    public void PDestroy()
    {
        Destroy(gameObject);
    }

    public bool GetCollide() {

        return Collide;

    }
    void Update () {
		
	}
}
