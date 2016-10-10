using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
public class EventTriggerListener : UnityEngine.EventSystems.EventTrigger{
	public delegate void VoidDelegate ();
	public VoidDelegate onClick;
	public VoidDelegate onDown;
	public VoidDelegate onEnter;
	public VoidDelegate onExit;
	public VoidDelegate onUp;
	public VoidDelegate onSelect;
	public VoidDelegate onUpdateSelect;
    public VoidDelegate onSubmit;

	static public EventTriggerListener Get (GameObject go)
	{
		EventTriggerListener listener = go.GetComponent<EventTriggerListener>();
		if (listener == null) listener = go.AddComponent<EventTriggerListener>();
		return listener;
	}
    public override void OnSubmit(BaseEventData eventData)
    {
        if (onSubmit != null) onSubmit();
    }
	public override void OnPointerClick(PointerEventData eventData)
	{
		if(onClick != null) 	onClick();
	}
	public override void OnPointerDown (PointerEventData eventData){
		if(onDown != null) onDown();
	}
	public override void OnPointerEnter (PointerEventData eventData){
		if(onEnter != null) onEnter();
	}
	public override void OnPointerExit (PointerEventData eventData){
		if(onExit != null) onExit();
	}
	public override void OnPointerUp (PointerEventData eventData){
		if(onUp != null) onUp();
	}
	public override void OnSelect (BaseEventData eventData){
		if(onSelect != null) onSelect();
	}
	public override void OnUpdateSelected (BaseEventData eventData){
		if(onUpdateSelect != null) onUpdateSelect();
	}
}