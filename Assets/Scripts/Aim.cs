using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

	private Vector2 worldMousePos;
	private Vector2 myFlatTransform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		myFlatTransform = new Vector2(transform.position.x, transform.position.y);
		transform.right = worldMousePos - myFlatTransform;
	}
}
