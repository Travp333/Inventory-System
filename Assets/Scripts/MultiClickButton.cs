 using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.Events;
 //This script was pulled from the internet, it allows buttons to be interacted with in more ways than just left clicking
 //gotten here: https://answers.unity.com/questions/993336/ui-button-detecting-right-mouse-button.html
 //Written by Cherno, modified by Travis
 public class MultiClickButton : MonoBehaviour, IPointerClickHandler {
 
	 public UnityEvent leftClick;
	 public UnityEvent middleClick;
	 public UnityEvent rightClick;
	 bool leftClickBlock = false;
	 bool rightClickBlock = false;
	 bool middleClickBlock = false;
	 [SerializeField]
	 [Tooltip("Amount of time the button is Unclickable after being pressed")]	 
	 float cooldown = 1f;
	 
	 void UnBlockLeft(){
	 	leftClickBlock = false;
	 }
	 void UnBlockRight(){
	 	Debug.Log("Right Click Free");
	 	rightClickBlock = false;
	 }
	 void UnBlockMiddle(){
	 	middleClickBlock = false;
	 }
 
	 public void OnPointerClick(PointerEventData eventData)
	 {
		if (eventData.button == PointerEventData.InputButton.Left){
			if(!leftClickBlock){
				leftClick.Invoke ();
				leftClickBlock = true;
				Invoke("UnBlockLeft", cooldown);
			}
		}
			 
		else if (eventData.button == PointerEventData.InputButton.Middle){
			if(!middleClickBlock){
				middleClick.Invoke ();
				middleClickBlock = true;
				Invoke("UnBlockMiddle", cooldown);
			}
			
		}
		
			 
		else if (eventData.button == PointerEventData.InputButton.Right){
			if(!rightClickBlock){
				rightClick.Invoke ();
				rightClickBlock = true;
				Invoke("UnBlockRight", cooldown);
			}
		 }
	 }
 }