using UnityEngine;
using System.Collections;

public class Maggot : MonoBehaviour {

	private bool _turnedRight;

	// Use this for initialization
	void Start ()
	{
		_turnedRight = Random.Range (0, 2) == 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (_turnedRight)
		{
			transform.position += new Vector3(Time.deltaTime, 0, 0);
		}
		else
		{
			transform.position += new Vector3(-Time.deltaTime, 0, 0);
		}
	}

	void Crush(PushParams pushParams)
	{
		Destroy (gameObject);
	}
}
