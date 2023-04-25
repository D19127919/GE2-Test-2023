using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotNodePositioning : MonoBehaviour
{
    private Boid boidParent;
    private Transform myPos;
    private Camera player;
    private FPSController playerController;

    [Tooltip("The speed at which the orb rotates")] public float rotateSpeed = 10;
    [Tooltip("+1 for clockwise rotation, -1 for counterclockwise rotation")] public int rotDirection = 1;
    [Tooltip("The distance relative to the parent boid to hover at")] public Vector3 offsetPos;
    public bool isControlled = false; //Whether the player is controlling this node
    [Tooltip("The cooldown between exiting a node and being able to re-control it")] public float controlCooldown = 3;
    private float controlTimer = 0;
    public KeyCode exitKey = KeyCode.Z;
    [Tooltip("How close the player must be to start controlling the node")] public float snapDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
        myPos = gameObject.transform; //quick get the transform as a shorter variable name
        boidParent = gameObject.GetComponentInParent<Boid>(); //assign the boid script we'll be "hijacking"
        player = Camera.main;
        playerController = player.GetComponent<FPSController>();

        if(boidParent = null) //If it doesn't exist (I.E. this object isn't childed to a Boid) destroy the object.
        {
            Destroy(gameObject);
        }

        myPos.position += offsetPos; //Set the position of the pilot seat
        myPos.localScale = new Vector3(1, 1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        //myPos.Rotate(0, rotateSpeed * Time.deltaTime, 0);

        if(Vector3.Distance(player.transform.position, myPos.position) < snapDistance && controlTimer <= 0)
        {
            isControlled = true;
            playerController.speed = 0;
            player.transform.position = new Vector3(Mathf.Lerp(player.transform.position.x, myPos.position.x, 0.2f), Mathf.Lerp(player.transform.position.y, myPos.position.y, 0.2f), Mathf.Lerp(player.transform.position.z, myPos.position.z, 0.2f));
            //player.gameObject.transform.rotation = Quaternion.RotateTowards(player.gameObject.transform.rotation, boidParent.gameObject.transform.rotation, 90 * Time.deltaTime);
        }

        if(isControlled)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                isControlled = false;
                controlTimer = controlCooldown;
                playerController.speed = 50;
            }
        }

        controlCooldown -= Time.deltaTime;
    }
}
