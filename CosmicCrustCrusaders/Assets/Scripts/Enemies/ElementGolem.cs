using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGolem : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GolemRock gl;

    [SerializeField]
    private float changeStateTime;
    private float timer;

    [SerializeField]
    private PlayerController player;
    private float distance;
    [SerializeField]
    private float playSoundDistance;
    private float originalSpeed;

    [SerializeField]
    private Collider2D tossCollider;
    private bool isStun;
    [SerializeField]
    private float stunTime;
    private float stunTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        originalSpeed =  gl.speed;
    }

    // Update is called once per 
    private void FixedUpdate()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= playSoundDistance)
        {
            AudioManager.Instance.PlayFireAndIceSFX("Golem");
        }
        if (!isStun)
        {
            timer += Time.fixedDeltaTime;
            if (timer >= changeStateTime && timer <= changeStateTime + 0.1f)
            {
                animator.SetTrigger("FGolem");
            }
            else if (timer >= changeStateTime * 2 && timer <= changeStateTime * 2 + 0.1f)
            {
                animator.SetTrigger("IGolem");
            }
            else if (timer >= changeStateTime * 2 + 0.5f)
            {
                timer = 0;
            }
            //Debug.Log(timer);
        }
        else if (isStun)
        {
            gl.speed = 0;
            animator.enabled = false;
            tossCollider.enabled = false;
            stunTimer += Time.deltaTime;
            if (stunTimer >= stunTime)
            {
                stunTimer = 0;
                tossCollider.enabled = true;
                gl.speed = originalSpeed;
                isStun = false;
                animator.enabled = true;
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toss"))
        {
            isStun = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playSoundDistance);
    }
}
