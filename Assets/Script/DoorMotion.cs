using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMotion : MonoBehaviour
{
    private Animator animator;

    void Start() // Start is called before the first frame update
    {
        animator = GetComponent<Animator>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        animator.SetBool("DoorIsOpening", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animator.SetBool("DoorIsOpening", false);
    }

    void Update() // Update is called once per frame
    {
        
    }
}
