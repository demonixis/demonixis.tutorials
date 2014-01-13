using UnityEngine;
using System.Collections;

public class demo : MonoBehaviour 
{
	private Rect _boxRect;
	private Rect _areaRect;

	void Start()
	{	 
		_boxRect = new Rect(Screen.width / 2 - 125,	Screen.height / 2 - 75, 250, 150);
		_areaRect = new Rect(_boxRect.x + 5, _boxRect.y + 40, _boxRect.width - 10, _boxRect.height - 10);
	}
	
	void OnGUI() 
	{
		GUI.Box(_boxRect, Lang.Get("game.title"));
		GUILayout.BeginArea(_areaRect);
		GUILayout.BeginVertical();
		GUILayout.Button(Lang.Get("game.new"));
		GUILayout.Space(10);
		GUILayout.Button(Lang.Get("game.settings"));
		GUILayout.Space(10);
		GUILayout.Button(Lang.Get("game.exit"));
		GUILayout.Space(10);
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}
}




