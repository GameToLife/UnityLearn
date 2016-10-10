using UnityEngine;
using System.Collections;

public class RockerTouch : UIBase {

    public UIButton rockItem;
    public float maxVector;
    public GameObject target;

    private Vector3 rockDotLocalPos;
    private Vector3 mouseStartPos = Vector3.zero;
    private Vector2 direction;

    void Start() 
    {
        rockDotLocalPos = rockItem.transform.localPosition;

    }

    void Awake() 
    {
        UIEventListener.Get(rockItem.gameObject).onDrag = OnDrag;
        UIEventListener.Get(rockItem.gameObject).onPress = OnPress;
    }

    void Update() 
    {
        PCControl();

    }

    void OnPress(GameObject _obj,bool _state) 
    {
        if (_state)
        {
            mouseStartPos = Input.mousePosition;
        }
        else 
        {
            mouseStartPos = Vector3.zero;
            rockItem.transform.localPosition = rockDotLocalPos;
            direction = Vector3.zero;
            BackToInit();
          
        }
        
    }

    void OnDrag(GameObject _obj,Vector2 _detal) 
    {
     //   Debug.Log(mouseStartPos);
        Vector3 detal = Input.mousePosition - mouseStartPos;
        if (detal.magnitude >maxVector)
        {
            detal = maxVector * detal.normalized;
        }
        rockItem.transform.localPosition = rockDotLocalPos + detal;
        direction = detal;

        PCControl();
        
      //  Debug.Log(detal);
       
    }

    void PCControl() 
    {
        GameCenter.instance.boat.Move(direction);
      //  Vector3 mousePos = Input.mousePosition;
     //   Debug.Log(mousePos);
    }

    void BackToInit() 
    {
        PCControl();
    }

    void PhoneControl() 
    {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("Start:" + touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {

            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("End:" + touch.position);
            }
        }
    }

}
