using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private AudioSource doorSqueak;
    private Animator animator;

    void Start() // Start is called before the first frame update
    {
        animator = GetComponent<Animator>();
        doorSqueak = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpening", true);
        doorSqueak.PlayDelayed(0.5f);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
        doorSqueak.PlayDelayed(0.7f);
    }

    void Update() // Update is called once per frame
    {
        
    }
}
