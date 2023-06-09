using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// enables/disables mesh renderer for child missile gameobject
public class MeshDisable : MonoBehaviour
{
    public MeshRenderer meshRenderer;

    void Start(){
        meshRenderer = GetComponent<MeshRenderer>();
    }
    
    public void meshEnable(bool setting){
        meshRenderer.enabled = setting;
    }

}
