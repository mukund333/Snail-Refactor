using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private int 			 bulletTrust;
   
    void Start()
    {
        rb2d 			= GetComponent<Rigidbody2D>();
    }
	
    void FixedUpdate()
    {
		rb2d.AddForce(-transform.right * bulletTrust);	
		
		StartCoroutine("OnDisableUnObjects");
    }
	
	IEnumerator OnDisableUnObjects()
		{
			yield return new WaitForSeconds(2f);
			
			gameObject.SetActive(false);
			
			StopCoroutine("OnDisableUnObjects");
		}
	
}
