using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Transform camera1;
    public Vector3 offset;
    private float selisih = 0;    
    public float speed = 2;
    //private bool canMove = true;
    Transform t;    
	// Use this for initialization
	void Start () {
        t = transform;        
	}
	
	// Update is called once per frame
	void Update () {
		if (/*player.position.x > 0f*/camera1.position.x < player.position.x)
        {
            selisih = player.position.x - camera1.position.x;
            //selisih = selisih + Time.deltaTime;
            //t.eulerAngles = Vector3.Lerp (t.eulerAngles, new Vector3(t.eulerAngles.x, -selisih * 10, t.eulerAngles.z), 0.005f);
            t.eulerAngles = (new Vector3(t.eulerAngles.x, -selisih * 10, t.eulerAngles.z));
        }

        if (camera1.position.x > player.position.x)
        {
            selisih = player.position.x - camera1.position.x;
            //selisih = selisih + Time.deltaTime;
            t.eulerAngles = (new Vector3(t.eulerAngles.x, -selisih * 10, t.eulerAngles.z));
            //t.eulerAngles = Vector3.Lerp(t.eulerAngles, new Vector3(t.eulerAngles.x, -selisih * 10, t.eulerAngles.z), 0.005f);
        }

        if (camera1.position.y < player.position.y)
        {
            selisih = player.position.y - camera1.position.y;
            //selisih = selisih + Time.deltaTime;
            t.eulerAngles = (new Vector3(selisih * 10, t.eulerAngles.y, t.eulerAngles.z));
            //t.eulerAngles = Vector3.Lerp(t.eulerAngles, new Vector3(selisih * 10, t.eulerAngles.y, t.eulerAngles.z), 0.005f);
        }

        if (camera1.position.y > player.position.y)
        {
            selisih = player.position.y - camera1.position.y;
            //selisih = selisih + Time.deltaTime;
            t.eulerAngles = (new Vector3(selisih * 10, t.eulerAngles.y, t.eulerAngles.z));
            //t.eulerAngles = Vector3.Lerp(t.eulerAngles, new Vector3(selisih * 10, t.eulerAngles.y, t.eulerAngles.z), 0.005f);
        }

        if (camera1.position.z < player.position.z)
        {
            selisih = player.position.z - camera1.position.z;
            t.Translate (0, 0, selisih);
            //Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, selisih, /*Time.deltaTime* */ speed);
        }

        if (camera1.position.z > player.position.z)
        {
            selisih = player.position.z - camera1.position.z;            
            t.Translate(0, 0, selisih);
            //Camera.main.fieldOfView = Mathf.MoveTowards(Camera.main.fieldOfView, selisih, -speed);
        }
    }
}
