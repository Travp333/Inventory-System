using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
      public GameObject player;
      public float cameraHeight = 20.0f;
      public float cameraHeight2 = 20.0f;
      public float cameraHeight3 = 20.0f;
  
      void Update() {
          Vector3 pos = player.transform.position;
          pos.z += cameraHeight;
          pos.y += cameraHeight2;
          pos.x += cameraHeight3;
          transform.position = pos;
      }
}
