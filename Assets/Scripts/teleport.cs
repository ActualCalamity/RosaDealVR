using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teleport : MonoBehaviour
{
    // Start is called before the first frame update
    public int destination;
    private int teleported;
    public GameObject playerrig;
    public Image fade;
    private float alpha;
    public GameObject floor1,floor2,floor3;
    public GameObject map1,map2,map3;
    public int keyb;
    void Start()
    {
        teleported = 0;
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(teleported==1)
        {
            if(alpha<1)
            {
                alpha+=0.05f;
                fade.color = new Color(0,0,0,alpha);
            }
            else
            {
                teleported = 0;
                if(keyb==0)
                {
                    playerrig.transform.position = new Vector3(0.0f,-0.26f,0.0f);
                }
                if(keyb==1)
                {
                    playerrig.transform.position = new Vector3(0.0f,1.07f,0.0f);
                }
                if(destination==1)
                {
                    floor1.SetActive(true);
                    floor2.SetActive(false);
                    floor3.SetActive(false);
                    map1.SetActive(true);
                    map2.SetActive(false);
                    map3.SetActive(false);
                }
                if(destination==2)
                {
                    floor1.SetActive(false);
                    floor2.SetActive(true);
                    floor3.SetActive(false);
                    map1.SetActive(false);
                    map2.SetActive(true);
                    map3.SetActive(false);
                }
                if(destination==3)
                {
                    floor1.SetActive(false);
                    floor2.SetActive(false);
                    floor3.SetActive(true);
                    map1.SetActive(false);
                    map2.SetActive(false);
                    map3.SetActive(true);
                }
            }
        }
        else{
            if(alpha>0)
            {
                alpha-=0.05f;
                fade.color = new Color(0,0,0,alpha);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            teleported = 1;
        }
    }
}
