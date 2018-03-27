using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : MonoBehaviour {

    private Transform cubetransform;

	// Use this for initialization
	void Start () {
        cubetransform = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
        {
            cubetransform.Translate(new Vector3(1,0,0));
        }
	}
}
