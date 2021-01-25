using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

	public int health = 20;

	public void TakeDamage (int amount)
	{
		health -= amount;

		if (health <= 0)
		{
			Die();
		}
	}

	public virtual void Die ()
	{

		Destroy(gameObject);
	}

}
