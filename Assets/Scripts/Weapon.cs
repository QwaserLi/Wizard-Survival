using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject {

	public GameObject spellPrefab;
	public float fireRate;

	public bool shootsRaycasts = false;
	public int raycastDamage = 20;

	public void Shoot (Transform firePoint)
	{
		GameObject spell = Instantiate(spellPrefab, firePoint.position, firePoint.rotation);
		spell.transform.localScale *= Progression.Growth;
		Destroy(spell, 10f);
	}

}
