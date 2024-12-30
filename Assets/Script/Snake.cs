using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;	//namespace for List()

public class Snake : MonoBehaviour {

	public GameObject food;
	public GameObject tailPrefab;
	public Transform lBorder;
	public Transform tBorder;
	public Transform rBorder;
	public Transform bBorder;

	Player mySnake = new Player ();

//	Vector2 vector=Vector2.right;
//	Vector2 moveVector;

	List<Transform> tail= new List<Transform>();

	void Awake(){
		mySnake.Speed = 0.1f;
		mySnake.Eat = false;
		mySnake.Vector = Vector2.right;
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Movement", 0.3f, mySnake.Speed);
		spawnFood ();
	}
	
	// Update is called once per frame
	void Update () {
		Control ();
	}

	public void spawnFood(){
		int x = (int)Random.Range (rBorder.position.x, lBorder.position.x);
		int y = (int)Random.Range (bBorder.position.y, tBorder.position.y);

		Instantiate (food, new Vector2 (x, y), Quaternion.identity);
	}
	void Movement(){

		Vector2 ta = transform.position;
		if (mySnake.Eat) {
			if (mySnake.Speed > 0.002f) {
				mySnake.Speed = mySnake.Speed - 0.002f;
			}
			GameObject g = (GameObject)Instantiate (tailPrefab, ta, Quaternion.identity);
			tail.Insert (0, g.transform);
			mySnake.Eat = false;
		} else if (tail.Count > 0) {
			tail.Last ().position = ta;
			tail.Insert (0, tail.Last ());
			tail.RemoveAt (tail.Count - 1);
		}
//		transform.Translate (moveVector);
		transform.Translate(mySnake.MoveVector);

	}

	bool horizontal=true;
	bool vertical;

	void Control(){

		if (Input.GetKey (KeyCode.UpArrow) && horizontal) {
			horizontal = false;
			vertical = true;
//			vector = Vector2.up;
			mySnake.Vector=Vector2.up;
		}
		else if (Input.GetKey (KeyCode.DownArrow) && horizontal) {
			horizontal = false;
			vertical = true;
//			vector = Vector2.down;
			mySnake.Vector=Vector2.down;
		}
		else if(Input.GetKey(KeyCode.RightArrow) && vertical){
			horizontal = true;
			vertical = false;
//			vector = Vector2.right;
			mySnake.Vector=Vector2.right;
		}
		else if(Input.GetKey(KeyCode.LeftArrow) && vertical){
			horizontal = true;
			vertical = false;
//			vector = Vector2.left;
			mySnake.Vector=Vector2.left;
		}

//		moveVector = vector / 3f;
		mySnake.MoveVector=mySnake.Vector/3f;
	}


	void OnTriggerEnter2D(Collider2D Col){
		if (Col.name.StartsWith ("food")) {
			mySnake.Eat = true;
			Destroy (Col.gameObject);
			spawnFood ();
		}
		else if(Col.tag=="box"){
			Debug.Log ("Game Over");
		}
	}
}
