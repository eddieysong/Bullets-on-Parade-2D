// Eddie Song 2017-07-04
// Script to control the behavior of a single enemy weapon

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
{

	[SerializeField]
	private EnemyWeaponConfigObject weaponConfig;

	[SerializeField]
	private float delayBeforeFiring = 1.25f;

	private float isMirror;
	private float isBoss;

	//	[SerializeField]
	//	private FiringPatternConfigObject firingPattern;

	// Use this for initialization
	public void LoadConfig (EnemyWeaponConfigObject weaponConf)
	{
		weaponConfig = weaponConf;

		if (weaponConfig != null && weaponConfig.firingPattern != null) {

			// if the weapon should fire in "mirror" mode, then multiply the angles by -1
			isMirror = gameObject.GetComponentInParent<EnemyMovementController> ().IsMirror ? -1 : 1;
			isBoss = gameObject.GetComponentInParent<EnemyMovementController> ().IsBoss ? 2f : 1;


			Debug.Log ("weapon config loaded");
			StartCoroutine (FireCycle ());
		}



	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	IEnumerator FireCycle ()
	{
		yield return new WaitForSeconds (delayBeforeFiring);
		while (this.enabled) {

			for (int i = 0; i < weaponConfig.firingPattern.numberOfShots; i++) {
				// instantiates a bullet using this.transform and rotation specified by bulletPattern
				GameObject newBullet = Instantiate (weaponConfig.bullet, this.transform.position, Quaternion.Euler (new Vector3 (0, 0, 
					                       isMirror * (weaponConfig.firingPattern.startAngle + (weaponConfig.firingPattern.endAngle - weaponConfig.firingPattern.startAngle)
					                       * i / weaponConfig.firingPattern.numberOfShots))));

				// sets the speed of the bullet according to bulletPatten;
				newBullet.GetComponent<Rigidbody2D> ().velocity = -newBullet.transform.up * weaponConfig.firingPattern.bulletSpeed;

				if (!weaponConfig.firingPattern.isBurstFire) {
					// if burst fire, spawn all bullets at the same time
					// if not burst fire, spawn bullets one by one
					// wait for time specified by both weapon (specifies delay multiplier) and firing pattern (specifies base delay)
					yield return new WaitForSeconds (weaponConfig.firingPattern.fireDuration / weaponConfig.firingPattern.numberOfShots / weaponConfig.fireRateMultiplier / isBoss);
				}
			}

			// wait for time between waves of bullets
			yield return new WaitForSeconds (weaponConfig.delayBetweenFiring / isBoss);
		}
	}
}
