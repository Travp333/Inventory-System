 using UnityEngine;
 using UnityEngine.EventSystems;
 using UnityEngine.Events;
 //This script was pulled from the internet, it allows buttons to be interacted with in more ways than just left clicking
 //gotten here: https://answers.unity.com/questions/993336/ui-button-detecting-right-mouse-button.html
 //Written by Cherno
 public class MultiClickButton : MonoBehaviour, IPointerClickHandler {
 
	 public UnityEvent leftClick;
	 public UnityEvent middleClick;
	 public UnityEvent rightClick;
 
	 public void OnPointerClick(PointerEventData eventData)
	 {
		 if (eventData.button == PointerEventData.InputButton.Left)
			 leftClick.Invoke ();
		 else if (eventData.button == PointerEventData.InputButton.Middle)
			 middleClick.Invoke ();
		 else if (eventData.button == PointerEventData.InputButton.Right)
			 rightClick.Invoke ();
	 }
 }