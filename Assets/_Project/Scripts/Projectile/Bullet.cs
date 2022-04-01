using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MixinBase
{
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private SpriteRenderer  spriteRenderer;
	[SerializeField] private BulletData		 bulletData;
	
	[SerializeField] private int 			 bulletTrust;
	[SerializeField] private int 			 giveDamage;
	[SerializeField] private int 			 takeDamage;
	[SerializeField] private int 			 health;
	

	private void Configure()
	{
		spriteRenderer.sprite		=	bulletData.bulletSprite;
		
		giveDamage 		=	bulletData.giveDamage;
		takeDamage 		=	bulletData.takeDamage;
		health			=	bulletData.health;
		
		
	}


   
    void Start()
    {
		rb2d 			= 	GetComponent<Rigidbody2D>();
		spriteRenderer	= 	GetComponent<SpriteRenderer>();
        Configure();
    }
	
    void FixedUpdate()
    {
		rb2d.AddForce(-transform.right * bulletTrust);	
		

    }
	
		
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag("Enemy"))
		{
			if (col.gameObject.TryGetComponent<Immortal>(out var immrtl))
			{
					if(immrtl.isImmortal.GetData())
					{
						Debug.Log("Immortal");
						KillBullet();
						return;
					}
			}
			
			if(col.gameObject.TryGetComponent<DamageTake>(out var GiveDmg))
			{
					Debug.Log("Give Damage");
					GiveDmg.Damage(giveDamage);
					TakingDamage(takeDamage);
			}
			
		}
	}
	
	private void KillBullet()
	{
		gameObject.SetActive(false);
		Configure();
	}
	
	private void TakingDamage(int damage)
	{
		health -= takeDamage;
		if(health <=0)
		{
			KillBullet();
		}
	}
	
	
}
