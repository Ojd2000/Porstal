using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameController : MonoBehaviour
{
	public GameObject player;
	public GameObject spawn;

	void Start ()
	{
		Destroy (player);
	}

	void OnMouseDown ()
	{
		//if (/*btn1 was pressed*/)
		//	Replay ();

		//else if (/*btn2 was pressed*/)
		//	Application.Quit ();
	}

	void Replay ()
	{
		Instantiate (player, spawn.transform.position, spawn.transform.rotation);
	}
}
