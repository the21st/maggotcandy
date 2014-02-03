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

	public Texture2D StartGameImage;
	public Texture2D GameOverImage;
	public GameObject GUIObject;

	public GameObject SmashFist;
	public GameObject SnortFist;

	private FistType _fistType = FistType.Smash;

	private GameObject _currentFist;

	private GameState _state = GameState.Start;
	
	private GUIStyle _textStyle;

	// Use this for initialization
	void Start ()
	{
		GUIObject.SetActive(false);

		Time.timeScale = 0;
		
		_textStyle = new GUIStyle ();
		_textStyle.normal.textColor = Color.white;
		_textStyle.fontSize = 26;
		_textStyle.alignment = TextAnchor.MiddleCenter;
	}

	public void GameOver()
	{
		Destroy(_currentFist);
		Time.timeScale = 0;
		_state = GameState.GameOver;
		GUIObject.SetActive(false);
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
					GUIObject.SetActive(true);
				}
				break;
			case GameState.Running:
				UpdateGame();
				break;
			case GameState.GameOver:
				if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0))
				{
					Application.LoadLevel("game");
				}
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

	void OnGUI()
	{
		switch (_state)
		{
			case GameState.Start:
				GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), StartGameImage);
				break;
			case GameState.Running:
				break;
			case GameState.GameOver:
				GUI.DrawTexture(new Rect(0,0, Screen.width, Screen.height), GameOverImage);

				var centerScreen = new Vector2(0.5f * Screen.width, 0.5f * Screen.height);

				GUI.Label (new Rect (centerScreen.x, centerScreen.y - 50, 0, 0), "SCORE: " + ScoreCounter.GetScore().ToString("D7"), _textStyle);
				break;
			default:
				throw new System.ArgumentOutOfRangeException();
		}
	}
}