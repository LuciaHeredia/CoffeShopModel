using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waiter2Motion : MonoBehaviour
{
    public Animator animator;

    void Start()     // Start is called before the first frame update
    {
        animator = GetComponent<Animator>();
    }

    void Update()    // Update is called once per frame
    {
        StartCoroutine(playAnimator());
    }

    IEnumerator playAnimator()
    {
        animator.SetInteger("state2",0);
        yield return new WaitForSeconds(6);
        animator.SetInteger("state2",1);
        yield return new WaitForSeconds(6);
        animator.SetInteger("state2",2);
        yield return new WaitForSeconds(6);
        animator.SetInteger("state2",3);
        yield return new WaitForSeconds(6);
    }


}
