using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class AutoFireButton : MonoBehaviour
{
	[SerializeField] RectTransform uiHandleRectTransform ;


	Image backgroundImage, handleImage ;


	Toggle toggle ;

	Vector2 handlePosition ;
   


   void Awake ( ) {
	   

      toggle = GetComponent <Toggle> ( ) ;

      handlePosition = uiHandleRectTransform.anchoredPosition ;

      backgroundImage = uiHandleRectTransform.parent.GetComponent <Image> ( ) ;
      handleImage = uiHandleRectTransform.GetComponent <Image> ( ) ;


      toggle.onValueChanged.AddListener (OnSwitch) ;
	  toggle.isOn=true;
	  
      if (toggle.isOn)
         OnSwitch (true) ;
   }

   void OnSwitch (bool on) {
	   	
		if(on==true)
			handleImage.enabled = true;
		else
			handleImage.enabled = false;
  
   }

   void OnDestroy ( ) {
      toggle.onValueChanged.RemoveListener (OnSwitch) ;
   }
}
