using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
		public string 	bulletName;
	    public Sprite 	bulletSprite;
		public int 		giveDamage;
		public int 		takeDamage;
		public int    	health;
}
