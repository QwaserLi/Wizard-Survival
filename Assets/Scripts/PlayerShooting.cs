using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

	public Transform firePoint;
	public Weapon leftWeapon;
	public Weapon rightWeapon;

	public LineRenderer lr;

	private float nextTimeOfFire = 0f;

	// Update is called once per frame
	void Update () {
		if (Input.GetButton("Fire1"))
		{
			if (Time.time >= nextTimeOfFire)
			{
				if (leftWeapon.shootsRaycasts)
				{
					ShootRaycast(leftWeapon);
				} else
				{
					leftWeapon.Shoot(firePoint);
				}

				nextTimeOfFire = Time.time + 1f / leftWeapon.fireRate;
			}
		}
		if (Input.GetButton("Fire2"))
		{
			if (Time.time >= nextTimeOfFire)
			{
				if (rightWeapon.shootsRaycasts)
				{
					ShootRaycast(rightWeapon);
				}
				else
				{
					rightWeapon.Shoot(firePoint);
				}

				nextTimeOfFire = Time.time + 1f / rightWeapon.fireRate;
			}
		}
	}

	void ShootRaycast (Weapon weapon)
	{
		RaycastHit2D[] hits = Physics2D.CircleCastAll(firePoint.position, lr.startWidth, firePoint.up);
		foreach (RaycastHit2D hit in hits)
		{
			Enemy enemy = hit.collider.GetComponent<Enemy>();
			if (enemy != null)
			{
				enemy.TakeDamage(weapon.raycastDamage);
			}
		}

		lr.SetPosition(0, firePoint.position);
		lr.SetPosition(1, firePoint.position + firePoint.up * 100);

		StartCoroutine(FlashLineRenderer());
	}

	IEnumerator FlashLineRenderer()
	{
		lr.enabled = true;

		yield return new WaitForSeconds(0.02f);

		lr.enabled = false;
	}
}
