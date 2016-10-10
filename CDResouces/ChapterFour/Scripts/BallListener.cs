using UnityEngine;
using System.Collections;
public class BallListener : MonoBehaviour {
    public static ArrayList clothColliders = new ArrayList();   //列表中储存了能与布料发生碰撞的对象
    public static ArrayList destoryGameobject = new ArrayList();
    public GameObject Emi;
    Cloth cloth;                                                //指定的布料对象
    void Start () {
        cloth = GameObject.Find("Cloth").GetComponent<Cloth>(); //初始化布料对象
    }
    void OnTriggerEnter(Collider target) {                  //碰撞检测
        removeCollider();                               //移除碰撞列表中的对象
        Quaternion q = new Quaternion();
        q.eulerAngles = new Vector3(270, 0, 0);
        GameObject fire = (GameObject)Instantiate(Emi, transform.position, q);
        if (!target.gameObject.name.Equals("Cloth")) {   //与布料对象发生碰撞
            destoryGameobject.Add(fire);
        }
        Destroy(gameObject);                            //进行自我销毁
    }
    void removeCollider() {
        clothColliders.Remove(new ClothSphereColliderPair(GetComponent<SphereCollider>())); //在碰撞列表中移除自身
        ClothSphereColliderPair[] cscp = new ClothSphereColliderPair[clothColliders.Count]; //重新声明碰撞列表
        for (int i = 0; i < cscp.Length; i++) {
            cscp[i] = (ClothSphereColliderPair)clothColliders[i];               //初始化碰撞列表
        }
        cloth.sphereColliders = cscp;                                           //设置碰撞列表
    }
}
