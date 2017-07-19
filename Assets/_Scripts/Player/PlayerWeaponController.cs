// Eddie Song 2017-06-27
// Player Weapon Controller Script, controls a single weapon on the player ship

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour {

	[SerializeField]
	private GameObject bullet;

	[SerializeField]
	private float damage, fireRate;

	private float fireTimer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > fireTimer + 1 / fireRate) {
			Instantiate (bullet, transform.position, this.transform.rotation).SendMessage ("SetDamage", damage, SendMessageOptions.DontRequireReceiver);
			fireTimer = Time.time;
		}
	}


}
