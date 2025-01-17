﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterState
{
	Default,
	Hitlocked,
	Dead,
}

public class CharacterDataModule : MonoBehaviour 
{
	static List<CharacterDataModule> s_AllCharacters = new List<CharacterDataModule>();

	public static CharacterDataModule GetCharacterByName(string name)
	{
		if (name == "") return null;

		for(int i = 0; i < s_AllCharacters.Count; i++)
		{
			if(s_AllCharacters[i].Name == name)
			{
				return s_AllCharacters[i];
			}
		}

		return null;
	}

	public string Name = "";

	public CharacterState State = CharacterState.Default;
	public bool IsMoving = false;
	public bool IsAttacking = false;
	public bool IsJumping = false;
	public int Direction = 1;

	public float CurrentHealthPoints = 0;
	public float MaxHealthPoints = 0;

	public void ChangeState(CharacterState newState)
	{
		if (State == CharacterState.Dead)
			return;
		State = newState;
	}

	void Awake()
	{
		if (!s_AllCharacters.Contains(this))
		{
			s_AllCharacters.Add(this);
		}
	}

	void OnDestroy()
	{
		if (s_AllCharacters.Contains(this))
		{
			s_AllCharacters.Remove(this);
		}
	}
}
