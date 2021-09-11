using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawer1Motion : MonoBehaviour
{
    public Animator animator;
    public GameObject camera;
    private AudioSource drawer1Sound;
    public Text drawerText;
    public GameObject frame;
    private bool drawerIsClosed, textIsOpen;

    void Start()     // Start is called before the first frame update
    {
        drawerIsClosed = true;
        textIsOpen = true;
        drawer1Sound = GetComponent<AudioSource>();
    }

    void Update()     // Update is called once per frame
    {
        RaycastHit hit;

        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit)) // camera on object(not to the void)
        {
            if(hit.distance<7 && hit.transform.gameObject == this.gameObject) // distance less than 7 and we focused on THIS(chest of drawers)
            {
                if(drawerIsClosed && !textIsOpen)
                {
                    drawerText.text = "Press [E] to OPEN.";
                    textIsOpen = true;
                    drawer1Sound.PlayDelayed(0.5f);
                }
                else if(!drawerIsClosed && textIsOpen)
                {
                    drawerText.text = "Press [E] to CLOSE.";
                    textIsOpen = false;
                    drawer1Sound.PlayDelayed(0.7f);
                }

                drawerText.gameObject.SetActive(true); // show text
                frame.gameObject.SetActive(true); // show frame text
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("Drawer1IsOpen", drawerIsClosed);
                    drawerIsClosed = !drawerIsClosed;
                }
            }
            else
            {
                drawerText.gameObject.SetActive(false); // turn off text
                frame.gameObject.SetActive(false); // turn off frame text
            }
        }
    }

}
