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
		if (weaponConfig != null && weaponConfig.firingPattern != null) {
			Debug.Log ("weapon config loaded");
			StartCoroutine (FireCycle());
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator FireCycle() {
		while (this.enabled) {
			for (int i = 0; i < weaponConfig.firingPattern.numberOfShots; i ++) {
				// instantiates a bullet using this.transform and rotation specified by bulletPattern
				GameObject newBullet = Instantiate (weaponConfig.bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 
					weaponConfig.firingPattern.startAngle + (weaponConfig.firingPattern.endAngle - weaponConfig.firingPattern.startAngle)
					* i / Mathf.Max(1, weaponConfig.firingPattern.numberOfShots - 1))));

				// sets the speed of the bullet according to bulletPatten;
				newBullet.GetComponent<Rigidbody2D> ().velocity = - newBullet.transform.up * weaponConfig.firingPattern.bulletSpeed;

				// wait for time specified by both weapon (specifies delay multiplier) and firing pattern (specifies base delay)
				// set delay to 0.1 sec in case the delay wasn't set
				yield return new WaitForSeconds (weaponConfig.firingPattern.fireDuration / weaponConfig.firingPattern.numberOfShots / weaponConfig.fireRateMultiplier);
			}
			// wait for time between waves of bullets
			yield return new WaitForSeconds (weaponConfig.delayBetweenFiring);
		}
	}
}
