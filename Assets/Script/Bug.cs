using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour {

	Vector2 vector=Vector2.right;
	Vector2 move;
	public float speed;

	void Start () {
		InvokeRepeating ("Movement", 0.3f, speed);
	}

	void Update () {
		Control ();
	}

	void Print<T, U>(T lhs, U rhs){
		Debug.Log (lhs+" "+rhs);
	}

	void Movement(){
		transform.Translate (move);
	}

	bool horizontal=true;
	bool vertical;

	void Control(){
		if (Input.GetKey (KeyCode.UpArrow) && horizontal) {
			vector = Vector2.up;
			horizontal = false;
			vertical = true;
//			Print<string, bool> ("up", horizontal);

		} else if (Input.GetKey (KeyCode.DownArrow) && horizontal) {
			vector = Vector2.down;
			horizontal = false;
			vertical = true;
//			Print<string, bool> ("down", horizontal);
		} else if (Input.GetKey (KeyCode.RightArrow) && vertical) {
			vector = Vector2.right;
			horizontal = true;
			vertical = false;
//			Print<string, bool> ("right", horizontal);
		} else if (Input.GetKey (KeyCode.LeftArrow) && vertical) {
			vector = Vector2.left;
			horizontal = true;
			vertical = false;
//			Print<string, bool> ("left", horizontal);
		}
		move = vector / 3f;
	}
}
