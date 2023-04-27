using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;
using UnityEngine.UI;

public class move : MonoBehaviour
{
    public Rigidbody player;
    public float speed;
    private int movement;
    private float mapappear,alpha;
    public RawImage minimap;
    // Start is called before the first frame update
    void Start()
    {
        movement = 1;
        mapappear = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
        if (OVRInput.Get(OVRInput.Button.Three)){
           mapappear=1; 
        }
        else{
            mapappear=0;
        }
        
        if(movement==1)
        {
            var Lthumbstickinput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
            float fixedY = player.position.y;
            player.position += (transform.right*Lthumbstickinput.x + transform.forward*Lthumbstickinput.y)*Time.deltaTime*speed;
            player.position = new Vector3(player.position.x,fixedY,player.position.z);

            Vector2 RthumbstickInput = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
            float rotationAngle = Mathf.Atan2(RthumbstickInput.x, RthumbstickInput.y) * Mathf.Rad2Deg;
            player.transform.Rotate(0, rotationAngle * speed/6 * Time.deltaTime, 0);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="wall")
        {
            movement = 0;
            var Lthumbstickinput = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick, OVRInput.Controller.LTouch);
            var RthumbstickInput = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);
            float fixedY = player.position.y;
            print("collide hua");
            if(Lthumbstickinput.x==0 && Lthumbstickinput.y==0)
            {
                player.position -= (transform.right*RthumbstickInput.x + transform.forward*RthumbstickInput.y)*0.12f*speed;
                player.position = new Vector3(player.position.x,fixedY,player.position.z);
            }
            else
            {
                player.position -= (transform.right*Lthumbstickinput.x + transform.forward*Lthumbstickinput.y)*0.12f*speed;
                player.position = new Vector3(player.position.x,fixedY,player.position.z);
            }
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
