using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;


public class PlayerController : MonoBehaviour
{
	public enum State
		{
			AutoFire,
			ManualFire
		}
	
	
	[Space]
	[Header("References")]
	[SerializeField] private Joystick 	  	 joystick;
	[SerializeField] private ShootTouch		 shootTouch;	
	[SerializeField] private CheckCoolDown2	 checkCoolDown;
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private Toggle 		 toggle;
	[SerializeField] private RectTransform 	 toggleRectTransform ;

	
	[Space]
	[Header("Curve Settings")]
	[SerializeField] private float 			 acc;
	[SerializeField] private float 			 accTime;
	[SerializeField] private AnimationCurve  accCurve;
	
	
	[Space]
	[Header("Check")]
	[SerializeField] private bool 			 shooting;
	[SerializeField] private float           magnitudeOfForce;
	[SerializeField] private Vector2 	  	 direction;
	[SerializeField] private float           offsetAngle 		= 57.29578f;
	
	[Space]
	[Header("Shooting Settings")]
	[SerializeField] private bool 			 isFire;
	[SerializeField] private bool 			 isAutoFire;
	[SerializeField] private State 			 state;
	
	[Space]
	[Header("Controller Settings")]
	[SerializeField] private float 		  	 turnRate;// 	= 8f;
	[SerializeField] private float 		  	 maxSpeed;
	
	void Awake()
    {
			isFire 			= false;
			rb2d 			= GetComponent<Rigidbody2D>();
            joystick 		= FindObjectOfType<FixedJoystick>();
			shootTouch 		= FindObjectOfType<ShootTouch>();
			checkCoolDown	= GetComponent<CheckCoolDown2>();
			toggle 			= toggleRectTransform.GetComponent<Toggle>();
    }
	
	private void Update()
	{
		ToggleFire();
		this.direction = new Vector2(this.joystick.Horizontal, this.joystick.Vertical);
		this.Rotate();
		//this.Shoot();
	
		switch (state){
				
				case State.AutoFire:
					
						if(checkCoolDown.Check() && isAutoFire)
						{
							checkCoolDown.Reset();
							isFire=true;
						}
					
                break;
				
				case State.ManualFire:
						
						if (Input.GetKey(KeyCode.S) || shootTouch.IsDown() ){
			
								if(checkCoolDown.Check()){
									checkCoolDown.Reset();
									isFire=true;
								}	
						}
						
				break;
		}
		
		
		
		
		

	}

	private void FixedUpdate()
	{
		 
		// this.direction = new Vector2(this.joystick.Horizontal, this.joystick.Vertical);
		// this.Rotate();
		// this.Shoot();
		magnitudeOfForce = rb2d.velocity.magnitude;
	}
	
	private void Rotate()
    {
          if (Mathf.Abs(direction.x) > 0.05f || Mathf.Abs(direction.y) > 0.05f)
          {
                float angle = Mathf.Atan2(direction.y, direction.x) * offsetAngle;//57.29578f;
                Quaternion b = Quaternion.AngleAxis(angle, new Vector3(0f, 0f, 1f));
                transform.rotation = Quaternion.Slerp(transform.rotation, b, Time.deltaTime * turnRate);//fixedDeltaTime
          }
    }
	
	
	// private void Shoot()
	// {
		// //if (Input.GetButton("Shoot") || this.shootButton.IsDown() || Input.GetAxis("ShootAxis") > 0f)
		// if (isFire)	
		// {
			// isFire=false;
			// acc = acc + 1f / accTime * Time.deltaTime;
			// rb2d.velocity = transform.right * (maxSpeed * accCurve.Evaluate(acc));
			// acc = Mathf.Clamp(acc, 0f, 1f);
			
			// if (!shooting)
			// {
				// shooting = true;
			
			// }
			// // if (Time.time - this.lastShotTime > 1f / fireRate)
			// // {
				// // //this.shootFunction();
				// // this.lastShotTime = Time.time;
			// // }
			
		// }
		// else
		// {
			// if (acc > 0f)
			// {
				// acc = this.rb2d.velocity.magnitude / maxSpeed;
			// }
			// if (this.shooting)
			// {
				// this.shooting = false;
				
			// }
		// }
	// }
	
	private void  ToggleFire(){
			if(toggle.isOn== true)
			{
				state = State.AutoFire;
			}else{
				
				state = State.ManualFire;
			}
			
		}
		
	// private void RecoilPhysics()
    // {
       // // Debug.Log("RecoilPhysics");
        // rb2d.drag = currentWeaponData.drag;
        // rb2d.AddForce(transform.right *currentWeaponData.thrust, ForceMode2D.Impulse);
    // }
	
	
}
