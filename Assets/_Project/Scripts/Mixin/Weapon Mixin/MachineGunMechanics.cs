using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunMechanics : MixinBase
{
	[SerializeField] private GameObject 	bulletPrefab;	
	[SerializeField] private GameObject 	shootPoint;
	[SerializeField] private GameObject     player;
	[SerializeField] private int			spread = 3;
	
    
	public override void Action()
	{
		Shoot();
	}
	
	private void Shoot()
    {
			float num = Random.Range(-spread, spread);
                
			Instantiate(bulletPrefab,shootPoint.transform.position, Quaternion.Euler(0f, 0f, player.transform.rotation.eulerAngles.z + num));	
	}
}
