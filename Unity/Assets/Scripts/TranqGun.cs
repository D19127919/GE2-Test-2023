using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranqGun : MonoBehaviour
{
    public float tranqtime = 5;
    public KeyCode shootKey = KeyCode.F;

    private float timer;
    private Transform victim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(shootKey) && victim == null)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                victim = hit.transform;

                if(victim.gameObject.GetComponent<Boid>() == null)
                {
                    victim = null;
                }
                else
                {
                    victim.gameObject.GetComponent<Boid>().isTranqued = true;

                    timer = tranqtime;
                }

                
            }
        }


        timer -= Time.deltaTime;

        if(timer <= 0 && victim != null)
        {
            victim.gameObject.GetComponent<Boid>().isTranqued = false;
        }
    }
}
