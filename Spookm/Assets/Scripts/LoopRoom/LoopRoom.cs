using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRoom : MonoBehaviour
{
    private int LoopCount;

    void Start()
    {
        LoopCount = 0;
    }

    public void UpdateLoop()
    {
        LoopCount++;
        Debug.Log("Loop: " + LoopCount);
    }


}
