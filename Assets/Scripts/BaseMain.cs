using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class BaseMain : MonoBehaviour
{
	public UILabel FPS;
	public UILabel Log;

	protected float GetFPS() { return 1.0f / Time.deltaTime; }

	void OnGUI()
	{
		int block = 80;
		string[] scenes = { "Garbage", "Sprites" };
		int y = 0;
		foreach(string s in scenes)
		{
			if (GUI.Button(new Rect(y, Screen.height - block, block, block), s)) Application.LoadLevel(s);
			y += block;
		}
	}

	protected void PushLog(string s)
	{
		print(s);
		Log.text += s + Environment.NewLine;
	}
}
