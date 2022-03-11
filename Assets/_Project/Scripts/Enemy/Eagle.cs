using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
	[SerializeField] private Rigidbody2D  	rb2d;
	
	[SerializeField] private float 			Speed;
	[SerializeField] private float 			turnRate;
	
	[SerializeField] private int 			baseHealth;
	[SerializeField] private int 			currentHealth;

	
	
	[SerializeField] private float	  		selfDestructTimer = 60f;
					 private float   		selfDestructTime;

	
	public Transform target;
	[SerializeField] private SpriteFlash 	spriteFlash;
	
	[SerializeField] private Vector2 		coinAmount;
	[SerializeField] private int 			coinID;
	
	
	private WaitForEndOfFrame waitForFrame = new WaitForEndOfFrame();
	
	public bool Test =false;
	
	void OnEnable()
    {
		target 		 = 	 GameObject.Find("Snail").transform;
		
		rb2d   		 =	 GetComponent<Rigidbody2D>();
		spriteFlash  =   GetComponent<SpriteFlash>();
		
		
		StartCoroutine(Behave());
    }
	
	void Start()
	{
		currentHealth = baseHealth;
		coinID = PoolManager.instance.GetPoolID("Coin");
	}
	
	
	
	void Update()
	{
		SelfDestruct();
		
		if(Test==true)
		{
			Test = false;
			Damage(1);
		}
	}
	
		
	private IEnumerator Behave()
	{
		while (base.gameObject.activeInHierarchy)
		{
			if (!this.target)
			{
				break;
			}
			Vector2 dir = target.position - transform.position;
			float angle = Mathf.Atan2(dir.y, dir.x) * 57.29578f;
			Quaternion rot = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
			transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * this.turnRate);
			rb2d.velocity = transform.right * Speed;
			yield return 0;
		}
		yield return 0;
		yield break;
	}

	public void Damage(int dmg)
	{
		currentHealth -= dmg;
		StartCoroutine(HitImmobalize());
		if(currentHealth <= 0)
		{
			Kill();
			
		}else
		{
			StartCoroutine(spriteFlash.SpriteFlashing());	
		}
		
	}


	public IEnumerator HitImmobalize()
	{
		float time = 0.1f;
		float timer = 0f;
		Vector3 pos = transform.position;
		while (timer < time)
		{
			timer += Time.deltaTime;
			yield return waitForFrame;
			transform.position = pos;
		}
		yield break;
	}



	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{		
				Kill();	
		}
	}



	public void DispenseCoins()
	{
		int num = (int)UnityEngine.Random.Range(this.coinAmount.x, this.coinAmount.y);
			
		for (int i = 0; i < num; i++)
		{
				PoolManager.instance.GetObject(this.coinID, base.transform.position, Quaternion.identity);
		}
		
	}



	public  void Kill()
	{
		currentHealth = baseHealth;
		DispenseCoins();
		gameObject.SetActive(false);
	}

	
	
	public void SelfDestruct()
	{
		selfDestructTime += Time.deltaTime;
				
		if(selfDestructTime>selfDestructTimer)
		{
			selfDestructTime = 0f;
			gameObject.SetActive(false);//Kill() hide becuse of coins
						
		}
	}
		
}
