using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworksOnDemandControl : MonoBehaviour
{
    void Start()
    {
        // todo: get some details and plug into our vfx
         
        // schedule our destruction once explosion compeltely over
        Destroy(gameObject, 10f);
    }

}
