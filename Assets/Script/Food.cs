using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	public GameObject food;
	public Transform lBorder;
	public Transform rBorder;
	public Transform tBorder;
	public Transform bBorder;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawnFood(){
		int x = (int)Random.Range (lBorder.position.x, rBorder.position.x);
		int y = (int)Random.Range (bBorder.position.y, tBorder.position.y);

		Instantiate (food, new Vector2 (x, y), Quaternion.identity);
	}
}
