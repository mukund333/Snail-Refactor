using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMomentum : MonoBehaviour
{
	[Space]
	[Header("References")]
	[SerializeField] private Rigidbody2D  	 rb2d;
	[SerializeField] private Joystick 	  	 joystick;	
	
	[Space]
	[Header("Check")]
	[SerializeField] private Vector2 	  	 direction;
	[SerializeField] private float           offsetAngle 		= 57.29578f;
	
	[Space]
	[Header("Controller Settings")]
	[SerializeField] private float 		  	 turnRate;// 	= 8f;
	[SerializeField] private float 			 angle;
	
	
	void Awake()
	{
		rb2d 			= GetComponent<Rigidbody2D>();
		joystick 		= FindObjectOfType<FixedJoystick>();
		// joystick.SnapX 	= true;
		// joystick.SnapY 	= true;	
	}
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     	 this.direction = new Vector2(this.joystick.Horizontal, this.joystick.Vertical);
		 this.Rotate();
	   
    }
	
	private void Rotate()
    {
          if (Mathf.Abs(direction.x) > 0.05f || Mathf.Abs(direction.y) > 0.05f)
          {
                 angle = Mathf.Atan2(direction.y, direction.x) * offsetAngle;//57.29578f;
                Quaternion b = Quaternion.AngleAxis((int)angle, new Vector3(0f, 0f, 1f));
                transform.rotation = Quaternion.Slerp(transform.rotation, b, Time.fixedDeltaTime * turnRate);//fixedDeltaTime
 	  			 //rb2d.MoveRotation(Quaternion.Slerp(rb2d.rotation,b,Time.fixedDeltaTime * turnRate));
  
          }
    }
}
