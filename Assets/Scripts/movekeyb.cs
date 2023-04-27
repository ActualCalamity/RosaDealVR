using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using UnityEngine.UI;

public class movekeyb : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
    private float rspeed, fspeed;
    private int movement;
    private float mapappear,alpha;
    public RawImage minimap;
    public float sensitivity = 100.0f;
    public float clampAngle = 80.0f;
    private float verticalRotation = 0.0f;
    private float horizontalRotation = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        movement = 1;
        mapappear = 0;
        fspeed=0;
        rspeed = 0;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalRotation += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        verticalRotation -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, -clampAngle, clampAngle);
        transform.localRotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0.0f);
        if(mapappear==1)
        {
            if(alpha<1)
            {
                alpha+=0.05f;
                minimap.color = new Color(1,1,1,alpha);
            }
        }
        else
        {
            if(alpha>0)
            {
                alpha-=0.05f;
                minimap.color = new Color(1,1,1,alpha);
            }
        }
        if (Input.GetKeyDown(KeyCode.M)){
           mapappear=1; 
        }
        if (Input.GetKeyUp(KeyCode.M)){
            mapappear=0;
        }
        player.position += new Vector3(transform.forward.x,0,transform.forward.z)*Time.deltaTime*fspeed;
        player.position += new Vector3(transform.right.x,0,transform.right.z)*Time.deltaTime*rspeed;
        if(movement==1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                if(fspeed<speed)
                {
                    fspeed+=0.2f;
                }
            }
            if((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.S)))
            {
                fspeed=0;
            }
            if (Input.GetKey(KeyCode.S))
            {
                if(fspeed>-1*speed)
                {
                    fspeed-=0.2f;
                }
            }
            if((Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.D)))
            {
                rspeed=0;
            }
            if (Input.GetKey(KeyCode.D))
            {
                if(rspeed<speed)
                {
                    rspeed+=0.2f;
                }
            }
            if (Input.GetKey(KeyCode.A))
            {
                if(rspeed>-1*speed)
                {
                    rspeed-=0.2f;
                }
            }            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="wall")
        {
            movement = 0;
            player.position -= other.contacts[0].normal*speed*-0.12f;
        }
    }
    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag=="wall")
        {
            movement=1;
        }
    }
}
