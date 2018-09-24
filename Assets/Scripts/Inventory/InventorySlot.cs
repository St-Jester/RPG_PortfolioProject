
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
	Item item;
	public Image icon;
	public Button removeButton;

	private void Awake()
	{
		//ClearSlot();
	}

	public void AddItemToSlot(Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;

		icon.enabled = true;

		removeButton.interactable = true;
	}

	public void ClearSlot()
	{
		item = null;

		icon.sprite = null;

		icon.enabled = false;

		removeButton.interactable = false;

	}

	public void OnRemoveButton()
	{
		Inventory.instace.Remove(this.item);


		// TODO: drop onfloor


	}

	public void UseItem()
	{
		if(item!=null)
		{
			item.Use();
			//TODO: handle removing from inventory!!!
			//item.RemoveFromInventory();
			
			//remove from slot
			//ClearSlot();
			
		}
	}
}
