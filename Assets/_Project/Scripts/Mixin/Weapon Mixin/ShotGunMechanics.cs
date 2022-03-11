using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGunMechanics : MixinBase
{
    [SerializeField] private GameObject 	bulletPrefab;	
	[SerializeField] private GameObject 	shootPoint;
	[SerializeField] private GameObject     player;
	[SerializeField] private int			spread = 25;
	
	
	
	public override void Action()
	{
		Shoot();
	}
	
	private void Shoot()
    {
			for (int i = 0; i < 5; i++)
            {
                
				float num = (float)UnityEngine.Random.Range(-spread, spread);	
				 //Instantiate(bulletPrefab,shootPoint.transform.position, Quaternion.Euler(0f, 0f, player.transform.rotation.eulerAngles.z + num));	
				 GameObject @object = PoolManager.instance.GetObject("Projectile", this.shootPoint.transform.position, Quaternion.Euler(0f, 0f, player.transform.rotation.eulerAngles.z + num));
            } 
			
		
		
		
	}
}
