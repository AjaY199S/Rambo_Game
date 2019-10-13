using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_controller : MonoBehaviour {

	public GameObject current;
	public GameObject next;
	public bool muteI;

	void Start () {
		current.SetActive (true);
		next.SetActive (false);
	}


	void Update () {
	}

	public void play_game(string Sceen_name)
	{
		Application.LoadLevel (Sceen_name);
	}
	public void game_quit()
	{
		Application.Quit ();
	}

	public void next_panel()
	{
		current.SetActive (false);
		next.SetActive (true);
	}
	public void MUTEfuc()
	{
		muteI =! muteI;
		AudioListener.volume = muteI ? 0 : 1;
	}
}
