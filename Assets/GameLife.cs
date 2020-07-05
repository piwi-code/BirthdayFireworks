using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLife : MonoBehaviour
{
    public float ThemeMusicStartDelay = 3f;

    private void Start()
    {
        // kick off background music
        var themeMusic = gameObject.GetComponent<AudioSource>();
        themeMusic?.PlayDelayed(ThemeMusicStartDelay);
    }

    void Update()
    {
        // handle exiting
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
