using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour {

	[SerializeField]
	private EnemyWeaponConfigObject weaponConfig;
//	[SerializeField]
//	private FiringPatternConfigObject firingPattern;

	// Use this for initialization
	public void LoadConfig (EnemyWeaponConfigObject weaponConf) {
		weaponConfig = weaponConf;
//		firingPattern = firingPatt;
		if (weaponConfig != null && weaponConfig.firingPattern != null && weaponConfig.firingPattern.bulletCycle.Length > 0) {
			Debug.Log ("weapon config loaded");
			StartCoroutine (FireCycle());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FireCycle() {
		while (this.enabled) {
			foreach (Vector3 bulletPattern in weaponConfig.firingPattern.bulletCycle) {
				// instantiates a bullet using this.transform and rotation specified by bulletPattern
				GameObject newBullet = Instantiate (weaponConfig.bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, bulletPattern.y)));

				// sets the speed of the bullet according to bulletPatten;
				newBullet.GetComponent<Rigidbody2D> ().velocity = - newBullet.transform.up * bulletPattern.x;

				// wait for time specified by both weapon (specifies delay multiplier) and firing pattern (specifies base delay)
				// set delay to 0.1 sec in case the delay wasn't set
				yield return new WaitForSeconds (1 / weaponConfig.fireRateMultiplier * bulletPattern.z);
//				yield return new WaitForSeconds (1 / weaponConfig.fireRateMultiplier * (bulletPattern.z == 0 ? 0.1f : bulletPattern.z));
			}
		}
	}
}
