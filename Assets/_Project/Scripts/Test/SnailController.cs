using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailController : MonoBehaviour
{
    public Joystick joystick;
	
	public float horizontalMove = 0f;
	public float verticalMove = 0f;
    public int runSpeed =10;
	
    void Start()
    {
        
    }

    
    void Update()
    {
        horizontalMove = joystick.Horizontal * runSpeed;
		verticalMove = joystick.Vertical * runSpeed;
		
		transform.Translate(new Vector3(horizontalMove,verticalMove,0) * Time.deltaTime);
    }
}
