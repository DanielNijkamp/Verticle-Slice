using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butterfly : MonoBehaviour
{
    private AnimationClip[] clips;
    private Animator animator;

    private float accelerationTime = 1;
    private float maxSpeed = 0.1f;
    private Vector2 movement;
    private float timeLeft;
    void Start()
    {
        PlayRandomly();
      

    }
    private void PlayRandomly()
    {
        
            int randInd = Random.Range(0, clips.Length);

            AnimationClip randClip = clips[randInd];

            animator.Play(randClip.name);
    }
    private void Awake()
    {
        animator = this.GetComponent<Animator>();
        clips = animator.runtimeAnimatorController.animationClips;
    }
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            movement = new Vector2(Random.Range(-0.1f, 0.1f), Random.Range(-0.1f, 0.1f));
            timeLeft += accelerationTime;
        }
    }
    private void FixedUpdate()
    {
        this.transform.Translate(movement * maxSpeed);
    }

}
