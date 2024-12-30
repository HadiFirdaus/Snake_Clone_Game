using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player{

	private float speed;
	private bool eat;
	private bool x;
	private bool y;
	private Vector2 vector;
	private Vector2 moveVector;

	public float Speed{
		get{ return speed;}
		set{ speed = value;}
	}
	public bool Eat{
		get{ return eat; }
		set{ eat = value; }
	}

	public bool X{
		get{ return x; }
		set{ x = value; }
	}

	public Vector2 Vector{
		get{ return vector; }
		set{ vector = value; }
	}

	public Vector2 MoveVector{
		get{ return moveVector; }
		set{ moveVector = value; }
	}

	public void Print<T, U>(T lhs, U rhs){
		Debug.Log (lhs + " " + rhs);
	}
}
