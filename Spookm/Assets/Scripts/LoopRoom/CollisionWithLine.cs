using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithLine : MonoBehaviour
{
    public GameObject LoopRoom;
    private LoopRoom _lrScript;

    void Start()
    {
        _lrScript = LoopRoom.GetComponent<LoopRoom>();
    }

    private void OnTriggerEnter()
    {
        _lrScript.UpdateLoop();
    }
}
