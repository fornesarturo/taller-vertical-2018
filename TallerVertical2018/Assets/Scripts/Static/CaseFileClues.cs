﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CaseFileClues {
	public string[] clues;

	public string ToString() {
		return JsonUtility.ToJson (this);
	}
}