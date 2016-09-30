using UnityEngine;
using System.Collections;

public class TestOne : UIBase {

    public void Click() 
    {
        UIMng.Instance.OpenUICloseOthers(UIType.TestTwo);
    }

}
