using System;
using System.Collections;
using System.Collections.Generic;
using Rubiks;
using Rubiks.Constants;
using UnityEngine;

public class RubiksController : MonoBehaviour
{
    [SerializeField] private RubiksCube rubiks;
    [SerializeField] private CameraController cam;
    [SerializeField] private bool turnMode = false;
    [SerializeField] private Transform[] sides;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Enable(bool b)
    {
        turnMode = b;
    }

    // Update is called once per frame
    void Update()
    {
        if (!turnMode) return;
        
        KeyCode[] keys = new KeyCode[] {KeyCode.L, KeyCode.R, KeyCode.U, KeyCode.I, KeyCode.F, KeyCode.B};

        foreach (KeyCode key in keys)
        {
            if (Input.GetKeyDown(key))
            {
                ExecuteTurn(key);
                break;
            }
        }
    }

    public void HandleButton(string s)
    {
        KeyCode key = Enum.Parse<KeyCode>(s);
        if (turnMode)
            ExecuteTurn(key);
        else
            cam.ShowSide(key); 
    }

    private void ExecuteTurn(KeyCode key)
    {
        switch(key)
        {
            case KeyCode.L: Turn(SideId.LEFT); break;
            case KeyCode.R: Turn(SideId.RIGHT); break;
            case KeyCode.U: Turn(SideId.UP); break;
            case KeyCode.I: Turn(SideId.DOWN); break;
            case KeyCode.F: Turn(SideId.FRONT); break;
            case KeyCode.B: Turn(SideId.DOWN); break;
        }
    }

    private void Turn(SideId id)
    {
        for (int i=0; i<6; i++)
        {
            sides[i].DetachChildren();
        }

        int idx = 0;
        Vector3 v = Vector3.zero;

        switch (id)
        {
            case SideId.LEFT : idx = 0; v = -Vector3.right; break;
            case SideId.RIGHT : idx = 1; v = -Vector3.right; break;
            case SideId.UP : idx = 2; v = -Vector3.up; break;
            case SideId.DOWN : idx = 3; v = Vector3.up; break;
            case SideId.FRONT : idx = 4; v = -Vector3.forward; break;
            case SideId.BACK : idx = 5; v = Vector3.forward; break;
        }

        rubiks.SelectSide(id, sides[idx]);

        // sides[idx].rotation = Quaternion.identity;
        // sides[idx].Rotate(v*90, Space.Self);
        rubiks.Turn(id, Direction.CW);

    }
}
