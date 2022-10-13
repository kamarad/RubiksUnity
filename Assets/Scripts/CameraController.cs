using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rubiks
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private Transform referencePoint;
        [SerializeField] private float modifier = 3;
        [SerializeField] private bool rotateMode = true;

        private float distance;

        // Start is called before the first frame update
        void Start()
        {
            distance = Vector3.Distance(referencePoint.position, cam.gameObject.transform.position);
        }

        public void Enable(bool b)
        {
            rotateMode = b;
        }

        // Update is called once per frame
        public void Update()
        {
            if (!rotateMode) return;

            if (Input.GetAxis("Vertical") != 0)
            {
                referencePoint.Rotate(new Vector3(Input.GetAxis("Vertical") * modifier, 0, 0), Space.World);
            }
            if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    referencePoint.Rotate(new Vector3(0, 0, Input.GetAxis("Horizontal") * modifier), Space.World);
                } else 
                {
                    referencePoint.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * modifier, 0), Space.World);
                }
            }

            KeyCode[] keys = new KeyCode[] {KeyCode.L, KeyCode.R, KeyCode.U, KeyCode.I, KeyCode.F, KeyCode.B};

            foreach (KeyCode key in keys)
            {
                if (Input.GetKeyDown(key))
                {
                    ShowSide(key);
                    break;
                }
            }            
        }

        public void ShowSide(KeyCode key)
        {
            switch(key)
            {
                case KeyCode.L: ShowSide(Vector3.down); break;
                case KeyCode.R: ShowSide(Vector3.up); break;
                case KeyCode.U: ShowSide(Vector3.right); break;
                case KeyCode.I: ShowSide(Vector3.left); break;
                case KeyCode.F: ShowSide(Vector3.zero); break;
                case KeyCode.B: ShowSide(Vector3.up*2); break;
            }
        }

        private void ShowSide(Vector3 v)
        {
            referencePoint.rotation = Quaternion.identity;
            referencePoint.Rotate(v*90, Space.Self);
        }

    }

}
