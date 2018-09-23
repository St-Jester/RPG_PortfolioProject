using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class Equipment : Item {

	public EquipmentSlot equipSlot;
	public SkinnedMeshRenderer mesh;
	public int armorModifier;
	public int damageModifier;
	public EquipmentMeshRegion[] coveredMeshes;

	public override void Use()
	{
		base.Use();
		//equip
		EquipmentManager.instace.EquipItem(this);
		//remove from inventory
		RemoveFromInventory();

		//TODO: refactor Inventorylot.ClearSlot(). use Inventory.instace.Remove(item); instead
	}
}


public enum EquipmentSlot
{
	Head,
	Chest,
	Legs,
	Weapon,
	Shield,
	Feet
}

public enum EquipmentMeshRegion
{
	Legs,
	Arms,
	Torso
}
