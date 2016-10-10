using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class MyButton : Selectable, IPointerClickHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler {
    //在属性面板中显示方法
    [SerializeField]
    UnityEvent m_OnClick = new UnityEvent();
    [SerializeField]
    UnityEvent m_OnDown = new UnityEvent();
    [SerializeField]
    UnityEvent m_OnEnter = new UnityEvent();
    [SerializeField]
    UnityEvent m_OnExit = new UnityEvent();
    [SerializeField]
    UnityEvent m_OnUp = new UnityEvent();
    [SerializeField]
    UnityEvent m_OnPress = new UnityEvent();
    //声明方法名
    public UnityEvent onClick {
        get {
            return m_OnClick;
        } set {
            m_OnClick = value;
        }
    }
    public UnityEvent onDown {
        get {
            return m_OnDown;
        } set {
            m_OnDown = value;
        }
    }
    public UnityEvent onEnter {
        get {
            return m_OnEnter;
        } set {
            m_OnEnter = value;
        }
    }
    public UnityEvent onExit {
        get {
            return m_OnExit;
        } set {
            m_OnExit = value;
        }
    }
    public UnityEvent onUp {
        get {
            return m_OnUp;
        } set {
            m_OnUp = value;
        }
    }
    public UnityEvent onPress {
        get {
            return m_OnPress;
        } set {
            m_OnPress = value;
        }
    }
    public virtual void OnPointerClick(PointerEventData eventData) {    //点击监听
        IgnoreError();
        m_OnClick.Invoke();
    }
    new public virtual void OnPointerDown(PointerEventData eventData) { //按下监听
        IgnoreError();
        //isPress = true;
        m_OnDown.Invoke();
    }
    new public virtual void OnPointerEnter(PointerEventData eventData) {    //鼠标进入监听
        IgnoreError();
        m_OnEnter.Invoke();
    }
    new public virtual void OnPointerExit(PointerEventData eventData) {     //鼠标离开监听
        IgnoreError();
        m_OnExit.Invoke();
    }
    new public virtual void OnPointerUp(PointerEventData eventData) {   //抬起监听
        IgnoreError();
        //isPress = false;
        m_OnUp.Invoke();
    }
    private void IgnoreError() {                    //判断按钮是否可用
        if (!IsActive() || !IsInteractable()) {
            return;
        }
    }
    /*  //按钮长按功能
    private bool isPress;
    private Selectable buttonSelectable;
    void Start() {
        buttonSelectable = GetComponent<Selectable>();
        if (!buttonSelectable) {
            buttonSelectable = gameObject.AddComponent<Selectable>();
        }
    }
    void Update() {
        if (isPress) {
            if (buttonSelectable.IsActive() && buttonSelectable.IsInteractable()) {
                m_OnPress.Invoke();
            }
        }
    }
     */ 
}