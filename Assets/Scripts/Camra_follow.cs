using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camra_follow : MonoBehaviour {

	public GameObject Player;

	Vector3 Offset;
	// Use this for initialization
	void Start () {
		Offset = transform.position - Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Player.transform.position + Offset;
		
	}
}
