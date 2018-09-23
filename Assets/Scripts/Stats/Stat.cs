using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat {
	[SerializeField]
	int baseValue;


	private List<int> modifiers = new List<int>();

	public void AddModifier(int modifierValue)
	{
		if(modifierValue != 0)
		{
			modifiers.Add(modifierValue);
		}
	}

	public void RemoveModifier(int modifierValue)
	{

		if (modifierValue != 0)
		{
			modifiers.Remove(modifierValue);
		}
	}

	public int GetValue()
	{

		int finalValue = baseValue;
		for (int i = 0; i < modifiers.Count; i++)
		{
			finalValue += modifiers[i];
		}


		return finalValue;
	}
}
