using UnityEngine;
using System;
using System.Collections;

public class MainGarbage : BaseMain
{
	private int _Count = 500;

	// Use this for initialization
	void Start()
	{
		Log.text = "";
	}

	// Update is called once per frame
	void Update()
	{
		FPS.text = "text=" + _Count + " : fps=" + (int)GetFPS();

		RunGarbageCollection(_Count);
	}

	void RunGarbageCollection(int count)
	{
		string box = "";
		for (int i = 0; i < count; i++) box += "a";
		System.GC.Collect();
	}

	public void OnPressAnywhere()
	{
		StartCoroutine(Add500());
	}

	IEnumerator Add500()
	{
		_Count += 500;
		for (int i = 0; i < 5; i++) yield return 0;
		PushLog("text=" + _Count + " : fps=" + (int)GetFPS());
	}
}
