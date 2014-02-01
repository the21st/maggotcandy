using UnityEngine;
using System.Collections;

public class GameOverGUI : MonoBehaviour {
	
	private GUIStyle _textStyle;
	
	// Use this for initialization
	void Start () {
		_textStyle = new GUIStyle ();
		_textStyle.normal.textColor = Color.black;
		_textStyle.fontSize = 26;
	}

	void OnGUI()
	{
		var scoreText = "GAME OVER";
		var centerScreen = Camera.main.WorldToScreenPoint (new Vector3 (0, 0, 0));
		GUI.Label (new Rect (centerScreen.x, centerScreen.y, 100, 100), scoreText, _textStyle);

		if (GUI.Button (new Rect(centerScreen.x, centerScreen.y + 100, 200, 50), "Try again"))
		{
			Application.LoadLevel("game");
		}
	}
}
