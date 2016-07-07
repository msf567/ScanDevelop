﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Collider))]
public class InteractiveObject : MonoBehaviour
{
	public bool interactedWith = false;
	public TextAsset InkFile;

	void Start ()
	{
	
	}

	void Update ()
	{
		if (interactedWith)
			GetComponent<Renderer> ().material.color = Color.green;
	}

	void OnInteract ()
	{
		
	}
}
