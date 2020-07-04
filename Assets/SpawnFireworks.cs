using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFireworks : MonoBehaviour
{
    public GameObject Fireworks;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // click?
        if (!Input.GetMouseButtonDown(0))
            return;

        // look for a hit
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit))
            return;

        // spawn!
        Instantiate(Fireworks, hit.point, Quaternion.identity, transform);
    }
}
