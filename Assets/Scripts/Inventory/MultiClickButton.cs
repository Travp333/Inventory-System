using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
//This script was pulled from the internet, it allows buttons to be interacted with in more ways than just left clicking
//gotten here: https://answers.unity.com/questions/993336/ui-button-detecting-right-mouse-button.html
//Written by Cherno, modified by Travis

//TODO I WANNA MAKE A SLIGHT DELAY WHEN YOU HOLD BEFORE IT ACTAULLY STARTS HOLDING SO THAT WHEN YOU TABBUTTON THE LITTLE BAR DOESN SHOW UP
public class MultiClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
 
	public UnityEvent leftClick;
	public UnityEvent middleClick;
	public UnityEvent rightClick;
	public UnityEvent rightHold;
	public UnityEvent leftHold;
	public UnityEvent middleHold;
	private bool pointerDown;
	private float pointerDownTimer;
	[SerializeField]
	private float requiredHoldTime;
	[SerializeField]
	private Image fillImage;
	PointerEventData eventData2;
	
	public void Update(){
		if(pointerDown){
			pointerDownTimer += Time.deltaTime;
			if(pointerDownTimer >= requiredHoldTime){
				if(eventData2.button == PointerEventData.InputButton.Left){
					leftHold.Invoke();
				}
				if(eventData2.button == PointerEventData.InputButton.Right){
					rightHold.Invoke();
				}
				if(eventData2.button == PointerEventData.InputButton.Middle){
					middleHold.Invoke();
				}
				Reset();
			}
			fillImage.fillAmount = pointerDownTimer / requiredHoldTime;
		}
	}
	
	public void Reset(){
		eventData2 = null;
		pointerDown = false;
		pointerDownTimer = 0;
		fillImage.fillAmount = pointerDownTimer/requiredHoldTime;
	}
	
	public void OnPointerUp(PointerEventData eventData){
		if(eventData2 != null){
			if(pointerDownTimer < requiredHoldTime){
				if(eventData2.button == PointerEventData.InputButton.Left){
					leftClick.Invoke();
				}
				if(eventData2.button == PointerEventData.InputButton.Right){
					rightClick.Invoke();
				}
				if(eventData2.button == PointerEventData.InputButton.Middle){
					middleClick.Invoke();
				}
			}
			Reset();
		}
		
	}
	public void OnPointerDown(PointerEventData eventData){
		pointerDown = true;
		eventData2 = eventData;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left){
			leftClick.Invoke();
		}	 	
		else if (eventData.button == PointerEventData.InputButton.Middle){
			middleClick.Invoke();
		}
		else if (eventData.button == PointerEventData.InputButton.Right){
				rightClick.Invoke();
			}
	}
}