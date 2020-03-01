using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public AudioSource audioData;
    public AudioClip cureClip; 
	public int health = 100;
	public bool dead = false;
	public int damage = 1000;

	public GameObject replaceWithThis;

	public void TakeDamage (int damage)
	{
		health -= damage;

		if (health <= 0 && dead == false)
		{
			Die();
		}
	}


	void Die ()
	{
		audioData.clip = cureClip;
		audioData.Play();
		dead = true;
        Instantiate(replaceWithThis,  gameObject.transform.position,  gameObject.transform.rotation);
		Destroy(gameObject);
	}

}