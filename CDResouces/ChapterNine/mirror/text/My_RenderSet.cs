using UnityEngine;
using System.Collections;

public class My_RenderSet : MonoBehaviour {
    public GameObject Mirror;
    public GameObject MirrorCase;
	// Use this for initialization
	void Start () {
        int intMirr = Mirror.GetComponent<Renderer>().material.renderQueue;//镜子的渲染优先级
        MirrorCase.GetComponent<Renderer>().material.renderQueue = intMirr - 1;//镜框的渲染优先级在镜子之后
	}
	
	// Update is called once per frame
	void Update () {
        int intMirr = Mirror.GetComponent<Renderer>().material.renderQueue;//镜子的渲染优先级
        MirrorCase.GetComponent<Renderer>().material.renderQueue = intMirr - 1;//镜框的渲染优先级在镜子之后

        if (Input.GetMouseButtonDown(0))
        { 
            
        }
	}
}
