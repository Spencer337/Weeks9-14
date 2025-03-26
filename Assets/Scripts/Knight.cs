using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    Animator animator;
    SpriteRenderer sr;
    AudioSource footstep;
    public AudioClip[] footsteps;  
    public float speed = 2;
    public bool canRun = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");

        //sr.flipX = (direction < 0);
        animator.SetFloat("Movement", Mathf.Abs(direction));
        if (direction < 0)
        {
            sr.flipX = true;
        }
        if (direction > 0)
        {
            sr.flipX = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            canRun = false;
        }
        if (canRun == true)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }
    }

    public void AttackHasFinished()
    {
        canRun = true;
    }

    public void FootstepSound()
    {
        Debug.Log("Playing");
        footstep.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);
        
    }
}
