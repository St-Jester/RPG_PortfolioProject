using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats {

	// Use this for initialization
	void Start () {
		EquipmentManager.instace.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newitem, Equipment olditem)
	{
		 
		if (newitem != null)
		{
			armor.AddModifier(newitem.armorModifier);
			damage.AddModifier(newitem.damageModifier);

		}

		if (olditem != null)
		{
			armor.RemoveModifier(olditem.armorModifier);
			damage.RemoveModifier(olditem.damageModifier); 
		}

	}
	public override void Die()
	{
		base.Die();

		//kill the player
		//TODO place for ads!!! in method KillPlayer

		PlayerManager.instance.KillPlayer();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
