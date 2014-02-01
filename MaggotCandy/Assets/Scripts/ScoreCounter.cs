using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {

	private static int _totalScore = 0;
	public Vector2 pos  = new Vector2(20, 40);
	public Vector2 size = new Vector2(20, 60);

	private GUIStyle _textStyle;

	// Use this for initialization
	void Start () {
		_totalScore = 0;
		_textStyle = new GUIStyle ();
		_textStyle.normal.textColor = Color.black;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void Add(int score)
	{
		_totalScore += score;
	}
	
	void OnGUI()
	{
		var scoreText = "SCORE: " + _totalScore.ToString("D5");
		GUI.Label (new Rect (pos.x, pos.y, size.x, size.y), scoreText, _textStyle);
	}
}
