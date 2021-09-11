using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaiterMotion : MonoBehaviour
{
    private Animator animator;

    void Start()    // Start is called before the first frame update
    {
        animator = GetComponent<Animator>();
    }

    void Update()    // Update is called once per frame
    {
        StartCoroutine(playAnimator());

    }

    IEnumerator playAnimator()
    {
        animator.SetInteger("state",1);
        yield return new WaitForSeconds(1);
        animator.SetInteger("state",2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("state",1);
        yield return new WaitForSeconds(1);
        animator.SetInteger("state",0);
        yield return new WaitForSeconds(1);
    }
}
