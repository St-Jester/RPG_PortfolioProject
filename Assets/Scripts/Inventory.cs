using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {


	#region Singletone
	public static Inventory instace;

	private void Awake()
	{
		if (instace != null)
		{
			Debug.LogWarning("Already have" + this.name);
			return;
		}
		else
		{
			instace = this;
		}

	}
	#endregion

	public delegate void OnItemChanged();
	public OnItemChanged OnItemChangedCallback;

	public List<Item> items = new List<Item>();
	public int space = 20;

	public bool Add (Item item)
	{
		if (!item.isDefaultItem)
		{
			if (items.Count >= space)
			{
				Debug.Log("Not enough space");
				return false;
			}
				items.Add(item);

			if (OnItemChangedCallback != null)
				OnItemChangedCallback();

				return true;
		}
		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);
		if (OnItemChangedCallback != null)
			OnItemChangedCallback();
	}

}
