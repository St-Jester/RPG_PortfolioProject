using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour {

	#region Singletone
	public static EquipmentManager instace;

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

	public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
	public OnEquipmentChanged onEquipmentChanged;

	public SkinnedMeshRenderer targetMesh;

	Equipment[] currentEquipment;
	public Equipment[] defaultItems;
	SkinnedMeshRenderer[] currentMeshes;
	Inventory inventory;

	private void Start()
	{
		inventory = Inventory.instace;
		int eqipmentCount = System.Enum.GetNames(typeof(EquipmentSlot)).Length;

		currentEquipment = new Equipment[eqipmentCount];
		currentMeshes = new SkinnedMeshRenderer[eqipmentCount];

		EquipDefaultItems();
	}

	public void EquipItem(Equipment newEquipment)
	{
		int slotindex = (int)newEquipment.equipSlot;

		Equipment oldEquipment = UnequipItem(slotindex);

		if(onEquipmentChanged!=null)
		{
			onEquipmentChanged.Invoke(newEquipment, oldEquipment);
		}

		SetEquipmentMeshShapes(newEquipment, 100);

		currentEquipment[slotindex] = newEquipment;

		SkinnedMeshRenderer newMesh = Instantiate<SkinnedMeshRenderer>(newEquipment.mesh);
		newMesh.transform.parent = targetMesh.transform;

		newMesh.bones = targetMesh.bones;
		newMesh.rootBone = targetMesh.rootBone;

		currentMeshes[slotindex] = newMesh;
	}

	public Equipment UnequipItem(int slotindex)
	{
		if (currentEquipment[slotindex] != null)
		{
			if(currentMeshes[slotindex] != null)
			{
				Destroy(currentMeshes[slotindex].gameObject);
			}
			Equipment oldEqipment = currentEquipment[slotindex];

			SetEquipmentMeshShapes(oldEqipment, 0);

			inventory.Add(oldEqipment);

			currentEquipment[slotindex] = null;

			if (onEquipmentChanged != null)
			{
				onEquipmentChanged.Invoke(null, oldEqipment);
			}

			return oldEqipment;
		}
		else
			return null;
	}

	public void SetEquipmentMeshShapes(Equipment item, int weight)
	{
		foreach (EquipmentMeshRegion blendShape in item.coveredMeshes)
		{
			targetMesh.SetBlendShapeWeight((int)blendShape, weight);
		}
	}


	public void UnequipAll()
	{
		for (int i = 0; i < currentEquipment.Length; i++)
		{
			UnequipItem(i);
		}
	}

	public void EquipDefaultItems()
	{
		foreach (Equipment eq in defaultItems)
		{
			EquipItem(eq);
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.U))
		{
			UnequipAll();
		}
	}
}
