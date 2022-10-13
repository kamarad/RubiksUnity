using System;
using Rubiks.Constants;
using UnityEngine;

namespace Rubiks
{
    [RequireComponent(typeof(MeshFilter))]
    public class RCube : MonoBehaviour
    {
        [SerializeField] private float cubeSize = 1f;
        [SerializeField] private Color32[] sideColors;

        public float Size {
            get {
                return cubeSize;
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            ColorCube();
        }

        public void ColorCube()
        {
            ColorCube(-1, -1, -1);
        }

        public void ColorCube(int x, int y, int z)
        {
            /**
            0 = front
            1 = up
            2 = back
            3 = down
            4 = right
            5 = left
            */
            Color32[] colors = new Color32[24];

            for (int i=0; i<6; i++) 
            {
                ColorSide(i, colors, sideColors[i]);
            }

            if (x == -1)
            {
                return;
            }
            
            Color32 black = new Color32(0, 0, 0, 255);
            if (x > 0)
            {
                ColorSide(4, colors, black);
            }
            if (y < 2)
            {
                ColorSide(1, colors, black);
            }
            if (z > 0)
            {
                ColorSide(2, colors, black);
            }
            if (x < 2)
            {
                ColorSide(5, colors, black);
            }
            if (y > 0)
            {
                ColorSide(3, colors, black);
            }
            if (z < 2)
            {
                ColorSide(0, colors, black);
            }


            GetComponent<MeshFilter>().mesh.SetColors(colors);
        }

        private void ColorSide(int side, Color32[] colors, Color32 color)
        {
            if (side == 1) 
            {
                colors[4] = color;
                colors[5] = color;
                colors[8] = color;
                colors[9] = color;
            } else if (side == 2)
            {
                colors[6] = color;
                colors[7] = color;
                colors[10] = color;
                colors[11] = color;
            } else
            {
                for (int i = 0; i < 4; i++)
                {
                    colors[i + side*4] = color;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }

        internal void Turn(SideId id, Direction d)
        {
            Vector3 v = Vector3.zero;

            switch (id)
            {
                case SideId.LEFT : v = -Vector3.right; break;
                case SideId.RIGHT : v = -Vector3.right; break;
                case SideId.UP : v = -Vector3.up; break;
                case SideId.DOWN : v = Vector3.up; break;
                case SideId.FRONT : v = -Vector3.forward; break;
                case SideId.BACK : v = Vector3.forward; break;
            }
            int angle = 90;
            if (d == Direction.CCW)
            {
                angle *=-1;
            }
            transform.Rotate(v*angle, Space.Self);
        }
    }
}
