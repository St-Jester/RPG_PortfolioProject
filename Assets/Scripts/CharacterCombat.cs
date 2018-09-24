using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour {

	public event System.Action OnAttack;

	public float attackSpeed = 1f;
	private float attackCooldown;
	private CharacterStats myStats;
	public float delay = 1f;

	private void Start()
	{
		myStats = GetComponent<CharacterStats>();
		attackCooldown = 1f / attackSpeed;

	}
	private void Update()
	{
		attackCooldown -= Time.deltaTime;
	}
	public void Attack(CharacterStats targetStats)
	{

		if (attackCooldown <= 0)
		{
			StartCoroutine(DoDamage(targetStats, delay));
			if (OnAttack != null)
			{
				OnAttack();
			}
			attackCooldown = 1f / attackSpeed;
		}
	}

	IEnumerator DoDamage(CharacterStats stats, float delay)
	{
		stats.TakeDamage(myStats.damage.GetValue());

		yield return new WaitForSeconds(delay);
	}
}
