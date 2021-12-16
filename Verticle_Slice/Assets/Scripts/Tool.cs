using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    public  Breakable_Prefab BP;
    public LayerMask _layer;
    public float toolrange;

    public AnimationClip[] axe_animations;
    public AnimationClip[] pickaxe_animations;
    public AnimationClip[] hoe_animations;
    public AnimationClip[] scythe_animations;

    public GameObject player;
    public Animator animator;

    public bool isAxe;
    public bool isPickaxe;
    public bool isHoe;
    public bool isScythe;

    public bool isCooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator cooldown(AnimationClip[] array, int dir)
    {
        isCooldown = true;
        yield return new WaitForSecondsRealtime(array[dir].length);
        isCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, 100f, _layer);
            if (hit.transform.gameObject.GetComponent<Breakable_Prefab>() != null && Vector3.Distance(this.transform.position, hit.transform.position) < toolrange)
            {
                BP = hit.transform.gameObject.GetComponent<Breakable_Prefab>();
                if (BP != null)
                {
                    GetObjectType();

                }
            }
            


        }
    }
    public void PlayAnimation(int array)
    {
        if (!isCooldown)
        {
            player.GetComponent<Movement>().isHitting = true;
            int dir = player.GetComponent<Movement>().direction;
            switch (array)
            {
                case 0:
                    animator.Play(hoe_animations[dir].name);
                    StartCoroutine(disableAnimator(hoe_animations, dir));
                    StartCoroutine(cooldown(hoe_animations, dir));
                    break;
                case 1:
                    animator.Play(axe_animations[dir].name);
                    StartCoroutine(disableAnimator(axe_animations, dir));
                    StartCoroutine(cooldown(axe_animations, dir));
                    break;
                case 2:
                    animator.Play(pickaxe_animations[dir].name);
                    StartCoroutine(disableAnimator(pickaxe_animations, dir));
                    StartCoroutine(cooldown(pickaxe_animations, dir));
                    break;
                case 3:
                    animator.Play(scythe_animations[dir].name);
                    StartCoroutine(disableAnimator(scythe_animations, dir));
                    StartCoroutine(cooldown(scythe_animations, dir));
                    break;

            }
        }
    }
    IEnumerator disableAnimator(AnimationClip[] array, int dir)
    {
        yield return new WaitForSeconds(array[dir].length);
        player.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Movement>().idlesprites[dir];
        animator.StopPlayback();
        player.GetComponent<Movement>().isHitting = false;
    }
    public void GetObjectType()
    {
        if (BP != null)
        {
            if (isHoe)
            {
                PlayAnimation(0);
            }
            else if (isAxe)
            {
                PlayAnimation(1);
            }
            else if (isPickaxe)
            {
                PlayAnimation(2);
            }
            else if (isScythe)
            {
                PlayAnimation(3);
            }
            
        }
    }
    
    
}
