using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	private static int _totalScore;
	public Vector2 pos  = new Vector2(20, 40);
	public Vector2 size = new Vector2(20, 60);

	private GUIStyle _textStyle;

	// Use this for initialization
	void Start () {
		_totalScore = 0;
		_textStyle = new GUIStyle ();
		_textStyle.normal.textColor = new Color(0, 183, 210);
		_textStyle.fontSize = 26;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Add(int score)
	{
		_totalScore += score;
	}

	public static int GetScore()
	{
		return _totalScore;
	}
	
	void OnGUI()
	{
		var scoreText = "SCORE: " + _totalScore.ToString("D7");
		GUI.Label (new Rect (pos.x, pos.y, size.x, size.y), scoreText, _textStyle);
	}
}
