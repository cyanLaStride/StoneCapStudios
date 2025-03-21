using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementGolem : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float changeStateTime;
    private float timer;

    [SerializeField]
    private PlayerController player;
    private float distance;
    [SerializeField]
    private float playSoundDistance;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per 
    private void FixedUpdate()
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
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance <= playSoundDistance)
        {
            AudioManager.Instance.PlayFireAndIceSFX("Golem");
        }
        //Debug.Log(timer);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, playSoundDistance);
    }
}
