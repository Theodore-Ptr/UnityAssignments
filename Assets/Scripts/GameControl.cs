using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// this class controls the game
/// </summary>
public class GameControl : MonoBehaviour
{
    //button support (may be here should be an event menager)
    public static event Action ButtonPressed = delegate { };

    [SerializeField]
    private Row[] rows;

    /// <summary>
    /// processes the button pressing
    /// </summary>
    public void OnButtonDown()
    {
        if(rows[0].RowStopped && rows[1].RowStopped && rows[2].RowStopped)
        {
            ButtonPressed();
        }
    }
}
