using System;
using System.Collections;
using System.Collections.Generic;
using Rubiks.Constants;
using UnityEngine;

namespace Rubiks
{
    public class RubiksCube : MonoBehaviour
    {
        public RCube[,,] cubes = new RCube[3,3,3];

        public void GenerateCubes(Transform spawnPoint, RCube prefab, float spacing)
        {
            Vector3 point = spawnPoint.position;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        point = spawnPoint.position + new Vector3(x - 1, y - 1, z - 1) * (prefab.Size + spacing);
                        GameObject c = GameObject.Instantiate(prefab.gameObject, point, Quaternion.identity);
                        c.transform.SetParent(spawnPoint);
                        c.name = "Cube " + (x*9 + y*3 + z);
                        cubes[x,y,z] = c.GetComponent<RCube>();
                        cubes[x,y,z].ColorCube(x, y, z);
                    }
                }
            }
        }

        public void ColorCubes()
        {
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int z = 0; z < 3; z++)
                    {
                        cubes[x,y,z].ColorCube(x, y, z);
                    }
                }
            }
        }

        public void SelectSide(SideId side, Transform container)
        {
            Axis axis = Axis.X;
            int idx = 0;

            switch (side)
            {
                case SideId.LEFT: axis = Axis.X; idx= 2; break;
                case SideId.RIGHT: axis = Axis.X; idx= 0; break;
                case SideId.UP: axis = Axis.Y; idx= 2; break;
                case SideId.DOWN: axis = Axis.Y; idx= 0; break;
                case SideId.FRONT: axis = Axis.Z; idx= 2; break;
                case SideId.BACK: axis = Axis.Z; idx= 0; break;
            }
            AddCubes(container, GetCubes(axis, idx));
        }

        private void AddCubes(Transform container, RCube[,] side)
        {
            for (int x=0; x<side.GetLength(0); x++) 
            {
                for (int y=0; y<side.GetLength(0); y++) 
                {
                    side[x,y].gameObject.transform.SetParent(container);
                }
            }
        }

        internal RCube[,] GetCubes(Axis axis, int index)
        {
            RCube[,] result = new RCube[3,3];

            int x,y,z;
            for (int i=0; i<3; i++) {
                for (int j=0; j<3; j++) {
                    switch (axis)
                    {
                        case Axis.X: 
                            x = index;
                            z = i;
                            y = j;
                            break;
                        case Axis.Y: 
                            y = index;
                            x = i;
                            z = j;
                            break;
                        default: 
                            z = index;
                            x = i;
                            y = j;
                            break;
                    }

                    result[i,j] = cubes[x,y,z];
                }
            }

            return result;
        }

        internal void Turn(SideId id, Direction d)
        {
            int x0,y0,z0;
            Axis axis = Axis.X;
            int idx = 0;

            switch (id)
            {
                case SideId.LEFT: axis = Axis.X; idx= 2; break;
                case SideId.RIGHT: axis = Axis.X; idx= 0; break;
                case SideId.UP: axis = Axis.Y; idx= 2; break;
                case SideId.DOWN: axis = Axis.Y; idx= 0; break;
                case SideId.FRONT: axis = Axis.Z; idx= 2; break;
                case SideId.BACK: axis = Axis.Z; idx= 0; break;
            }

            RCube[,] side = GetCubes(axis, idx);

            for (int i=0; i<3; i++) {
                for (int j=0; j<3; j++) {
                    switch (axis)
                    {
                        case Axis.X: 
                            x0 = idx;
                            z0 = i;
                            y0 = j;
                            break;
                        case Axis.Y: 
                            y0 = idx;
                            x0 = i;
                            z0 = j;
                            break;
                        default: 
                            z0 = idx;
                            x0 = i;
                            y0 = j;
                            break;
                    }
                    if (d == Direction.CCW) 
                    {
                        int inv = (i == 0 ? 2 : (i == 2 ? 0 : 1));
                        cubes[x0,y0,z0] = side[j, inv];
                    } else 
                    {
                        int inv = (j == 0 ? 2 : (j == 2 ? 0 : 1));
                        cubes[x0,y0,z0] = side[inv, i];
                    }

                    // cubes[x0,y0,z0].Turn(id, d);
                }
            }
        }

        void Update() 
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                for (int x=0; x<3; x++) 
                {
                    for (int y=0; y<3; y++) 
                    {
                        for (int z=0; z<3; z++) 
                        {
                            Debug.Log(cubes[x,y,z].name);
                        }
                    }
                }
            }
        }
    }
}
