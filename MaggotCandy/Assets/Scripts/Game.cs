using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	private enum FistType
	{
		Smash,
		Snort,
	}

	private enum GameState
	{
		Start,
		Running,
		GameOver
	}

	public GameObject SmashFist;
	public GameObject SnortFist;

	private FistType _fistType = FistType.Smash;

	private GameObject _currentFist;

	private GameState _state = GameState.Start;

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = 0;
	}

	void GameOver()
	{
		Time.timeScale = 0;
		_state = GameState.GameOver;
	}

	// Update is called once per frame
	void Update ()
	{
		switch (_state)
		{
			case GameState.Start:
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
				{
					Time.timeScale = 1;
					_state = GameState.Running;
					_currentFist = (GameObject)Instantiate (SmashFist, Extensions.GetMousePosition3D (), Quaternion.identity);
				}
				break;
			case GameState.Running:
				UpdateGame();
				break;
			case GameState.GameOver:
				break;
			default:
				throw new System.ArgumentOutOfRangeException();
		}
	}

	void UpdateGame()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(1) || Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			switch (_fistType)
			{
				case FistType.Smash:
					_fistType = FistType.Snort;
					Destroy(_currentFist);
					_currentFist = (GameObject)Instantiate(SnortFist, Extensions.GetMousePosition3D(), Quaternion.identity);
					break;
				case FistType.Snort:
					_fistType = FistType.Smash;
					Destroy(_currentFist);
					_currentFist = (GameObject)Instantiate(SmashFist, Extensions.GetMousePosition3D(), Quaternion.identity);
					break;
				default:
					throw new System.ArgumentOutOfRangeException();
			}
		}
	}
}