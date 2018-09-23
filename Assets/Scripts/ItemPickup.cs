using System;
using UnityEngine;

public class ItemPickup : Interactable {

	public Item item;

	public override void Interact()
	{
		base.Interact();

		PickUp();
	}

	public void PickUp()
	{
		Debug.Log("Picked Up " + item.name);
		//add to inventory
		bool hasPickedUp = Inventory.instace.Add(item);

		if(hasPickedUp)
			Destroy(this.gameObject);
	}
}
