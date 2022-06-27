using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    GameObject[] boost;
    void Update()
    {
        if (Input.GetKeyDown("w")){
            boost[0].SetActive(true);
        }
        if(Input.GetKeyUp("w")){
            boost[0].SetActive(false);
        }
        if (Input.GetKeyDown("s")){
            boost[1].SetActive(true);
        }
        if(Input.GetKeyUp("s")){
            boost[1].SetActive(false);
        }
        if (Input.GetKeyDown("a")){
            boost[2].SetActive(true);
        }
        if(Input.GetKeyUp("a")){
            boost[2].SetActive(false);
        }
        if (Input.GetKeyDown("d")){
            boost[3].SetActive(true);
        }
        if(Input.GetKeyUp("d")){
            boost[3].SetActive(false);
        }
    }
}
