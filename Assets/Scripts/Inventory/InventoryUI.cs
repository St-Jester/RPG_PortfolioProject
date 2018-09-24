using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour {

	public GameObject InventoryCanvas;

	bool isActive = false;
	Inventory inventory;
	InventorySlot[] slots;
	public Transform itemsParent;

	
	void Start () {
		inventory = Inventory.instace;
		inventory.OnItemChangedCallback += UpdateUI;

		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	private void UpdateUI()
	{
		Debug.Log("Updating UI");

		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)
			{
				slots[i].AddItemToSlot(inventory.items[i]);
			}
			else
			{
				slots[i].ClearSlot(); 
			}
		}
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Inventory"))
		{
			isActive = !isActive;
			InventoryCanvas.SetActive(isActive);
		}
	}
}
