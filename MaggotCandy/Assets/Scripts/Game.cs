using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private enum FistType
	{
		Smash,
		Snort,
	}

	public GameObject SmashFist;
	public GameObject SnortFist;

	private FistType _fistType = FistType.Smash;

	private GameObject _currentFist;

	// Use this for initialization
	void Start ()
	{
		_currentFist = (GameObject)Instantiate (SmashFist, Extensions.GetMousePosition3D (), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetMouseButtonDown (1) || Input.GetAxis ("Mouse ScrollWheel") != 0)
		{
			switch (_fistType)
			{
			case FistType.Smash:
				_fistType = FistType.Snort;
				Destroy(_currentFist);
				_currentFist = (GameObject)Instantiate (SnortFist, Extensions.GetMousePosition3D (), Quaternion.identity);
				break;
			case FistType.Snort:
				_fistType = FistType.Smash;
				Destroy(_currentFist);
				_currentFist = (GameObject)Instantiate (SmashFist, Extensions.GetMousePosition3D (), Quaternion.identity);
				break;
			default:
				throw new System.ArgumentOutOfRangeException ();
			}
		}
	}
}