using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField]
    GameObject[] boost;
    ParticleSystem part, part1, part2;
    void Update()
    {
        if (Input.GetKeyDown("w")){
            part = boost[0].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = true;
            part1 = boost[1].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = true;
            part2 = boost[3].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = true;

            boost[2].SetActive(true);
        }
        if(Input.GetKeyUp("w")){
            part = boost[0].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = false;
            part1 = boost[1].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = false;
            part2 = boost[3].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = false;


            boost[2].SetActive(false);
        }
        if (Input.GetKeyDown("s")){
            part = boost[4].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = true;
            part1 = boost[5].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = true;
            part2 = boost[7].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = true;

            boost[6].SetActive(true);
        }
        if(Input.GetKeyUp("s")){
            part = boost[4].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = false;
            part1 = boost[5].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = false;
            part2 = boost[7].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = false;

            boost[6].SetActive(false);
        }
        if (Input.GetKeyDown("a")){
            part = boost[8].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = true;
            part1 = boost[9].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = true;
            part2 = boost[11].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = true;

            boost[10].SetActive(true);
        }
        if(Input.GetKeyUp("a")){
            part = boost[8].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = false;
            part1 = boost[9].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = false;
            part2 = boost[11].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = false;

            boost[10].SetActive(false);
        }
        if (Input.GetKeyDown("d")){
            part = boost[12].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = true;
            part1 = boost[13].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = true;
            part2 = boost[15].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = true;

            boost[14].SetActive(true);
        }
        if(Input.GetKeyUp("d")){
            part = boost[12].GetComponent<ParticleSystem>();
            var em = part.emission;
            em.enabled = false;
            part1 = boost[13].GetComponent<ParticleSystem>();
            var em1 = part1.emission;
            em1.enabled = false;
            part2 = boost[15].GetComponent<ParticleSystem>();
            var em2 = part2.emission;
            em2.enabled = false;

            boost[14].SetActive(false);
        
        }
    }
}
