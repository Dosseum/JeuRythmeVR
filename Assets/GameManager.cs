using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameManager
{
    public static int score = 0;
	
	public static void UpdateScore() {
		GameObject.Find("score").GetComponent<UnityEngine.UI.Text>().text = (score).ToString();
	}
}
