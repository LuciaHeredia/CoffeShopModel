using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoverGlassMotion : MonoBehaviour
{
    public Animator animator;
    public GameObject coverGlassCamera;
    private AudioSource coverGlassSound;
    public Text coverGlassText;
    public GameObject coverGlassFrame;
    private bool coverGlassIsClosed, textIsOpen;

    void Start()    // Start is called before the first frame update
    {
        coverGlassIsClosed = true;
        textIsOpen = true;
        coverGlassSound = GetComponent<AudioSource>();
    }

    void Update()    // Update is called once per frame
    {
        RaycastHit hit2;

        if(Physics.Raycast(coverGlassCamera.transform.position, coverGlassCamera.transform.forward, out hit2)) // camera on object(not to the void)
        {
            if(hit2.distance<7 && hit2.transform.gameObject == this.gameObject) // distance less than 7 and we focused on THIS
            {
                if(coverGlassIsClosed && !textIsOpen)
                {
                    coverGlassText.text = "Press [E] to OPEN.";
                    textIsOpen = true;
                    coverGlassSound.PlayDelayed(0.5f);
                }
                else if(!coverGlassIsClosed && textIsOpen)
                {
                    coverGlassText.text = "Press [E] to COVER.";
                    textIsOpen = false;
                    coverGlassSound.PlayDelayed(0.7f);
                }

                coverGlassText.gameObject.SetActive(true); // show text
                coverGlassFrame.gameObject.SetActive(true); // show frame text
                
                if(Input.GetKeyDown(KeyCode.E))
                {
                    animator.SetBool("CoverGlassIsOpen", coverGlassIsClosed);
                    coverGlassIsClosed = !coverGlassIsClosed;
                }

            }
            else
            {
                coverGlassText.gameObject.SetActive(false); // turn off text
                coverGlassFrame.gameObject.SetActive(false); // turn off frame text
            }

        }
    }
}
