using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsEngine : MonoBehaviour
{
	public enum State
		{
			CurvePhysics,
			ForcePhysics
		}
		 
	
		
	
	[Space]
	[Header("References")]
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private ShootTouch		 shootTouch;
	//[SerializeField] private CheckCoolDown2	 checkCoolDown;
	
	
	[Space]
	[Header(" ")]
	[SerializeField] private State state = State.ForcePhysics;
	
	[Space]
	[Header("ForcePhysics Settings")]
	[SerializeField] private bool 			 isRecoiling;
					 public bool 			 isApplyingThrust;
	[SerializeField] private float           magnitudeOfForce;
	
	[Space]
	[Header("CurvePhysics Settings")]
	[SerializeField] private float 			 accThrust;
	[SerializeField] private float 			 accTimeThrust;
	[SerializeField] private AnimationCurve  accCurveThrust;
	
	[Space]
	[Header("Weapon Settings")]
	[SerializeField] private float 		  	 weaponThrust;
	[SerializeField] private float 		  	 weaponDrag;
	
	
	
	[Space]
	[Header("DragCurve Settings")]
	[SerializeField] private float 			 accDrag;
	[SerializeField] private float 			 accTimeDrag;
	[SerializeField] private AnimationCurve  accCurveDrag;
	
	
    private void Awake()
	{
		rb2d 				= 	GetComponent<Rigidbody2D>();
		shootTouch 			= 	FindObjectOfType<ShootTouch>();
		//checkCoolDown		= 	GetComponent<CheckCoolDown2>();
		
		accTimeDrag 		= 	1f;
		accTimeThrust		= 	1f;
		
		isRecoiling 		= 	false;
		isApplyingThrust	= 	false;
	}
    private void Start()
    {
        
    }

   
    private void Update()
    {
	
		magnitudeOfForce = VelocityMagnitude();
		
		switch (state)
		{
				
				case State.CurvePhysics:
					
							
					

                break;
				
				case State.ForcePhysics:
		
							if (Input.GetKey(KeyCode.S) || shootTouch.IsDown())
							{
								
								// if(checkCoolDown.Check())
								// {
									// checkCoolDown.Reset();
									isApplyingThrust = true;
									
									
								// }
				
							}
							
							if(VelocityMagnitude() > 0){
								isRecoiling = true;
								isApplyingThrust = false;
							}
		
							
							if(VelocityMagnitude() == 0){
								isRecoiling = false;
							}
				
					break;
		}
		
		
		
		
    }
	 

	 
	 
	private void FixedUpdate()
    {
		switch (state)
		{
				
				case State.CurvePhysics:	
					
					CurveRecoil();
					ApplyDragCurve();

                break;
				
				case State.ForcePhysics:
					
					if(isRecoiling == false && isApplyingThrust == true)
					{
		
						ForceRecoil();
					}
					
					if(isRecoiling==true)
					{
						ApplyDragCurve();	
					}
				
				break;
		}
		
		
		
    }
	
	private void ForceRecoil()
    {
		
		rb2d.drag = weaponDrag;
        rb2d.AddForce(transform.right * weaponThrust, ForceMode2D.Impulse);
    }
	
	private void CurveRecoil()
	 {    

        if (Input.GetKey(KeyCode.S) || shootTouch.IsDown())
		{ 

			accThrust = accThrust + 1f / accTimeThrust * Time.deltaTime;
			rb2d.velocity = transform.right * (weaponThrust * accCurveThrust.Evaluate(accDrag));
			accThrust = Mathf.Clamp(accThrust, 0f, 1f);
        
			if (accThrust > 0f)
			{
				accThrust = this.rb2d.velocity.magnitude / weaponThrust;
			}
		}
    }
	
	
	
	private void ApplyDragCurve()
	{
			accDrag = accDrag + 1f / accTimeDrag * Time.deltaTime;
			rb2d.drag = weaponDrag * accCurveDrag.Evaluate(accDrag);
			accDrag = Mathf.Clamp(accDrag, 0f, 1f);
	}
	
	
	private int VelocityMagnitude()
    {
        return (int)rb2d.velocity.magnitude;
    }
	
}
	