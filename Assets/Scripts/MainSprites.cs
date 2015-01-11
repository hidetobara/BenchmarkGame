using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MainSprites : BaseMain
{
	public GameObject Panel;
	public UIAtlas Atlas;

	private List<UISprite> _Sprites = new List<UISprite>();

	void Start()
	{
		Log.text = "";
		StartCoroutine(Making500());		
	}

	void Update()
	{
		if (Time.deltaTime > 0) FPS.text = "Sprite=" + (_Sprites.Count) + ": " + (int)GetFPS() + " fps";
	}

	public void OnPressAnywhere()
	{
		PushLog("sprites=" + _Sprites.Count + " : fps=" + GetFPS());
		StartCoroutine(Making500());
	}

	IEnumerator Making500()
	{
		for(int i = 0; i < 500; i++)
		{
			Make();
			yield return 0;
		}
	}

	void Make()
	{
		GameObject go = new GameObject();
		go.transform.parent = Panel.transform;
		UISprite sprite = go.AddComponent<UISprite>();
		sprite.atlas = Atlas;
		sprite.spriteName = "clock" + UnityEngine.Random.Range(0, 3);
		sprite.SetDimensions(64, 64);
		_Sprites.Add(sprite);
		int index = _Sprites.Count;

		go.name = "clock" + index;
		go.transform.localScale = Vector3.one;
		int x = UnityEngine.Random.Range(-Screen.width/2, Screen.width/2);
		int y = UnityEngine.Random.Range(-Screen.height/2, Screen.height/2);
		go.transform.localPosition = new Vector3(x, y, 0);

		sprite.depth = index;
	}
}
