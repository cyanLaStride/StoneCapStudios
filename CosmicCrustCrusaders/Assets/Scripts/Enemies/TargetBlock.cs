using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBlock : MonoBehaviour
{
    private Renderer ren;
    [SerializeField]
    private Color changeColor;
    private Color orignalColor;
    private float timer;
    private float maxTime = 3f;
    [SerializeField]
    private bool isChanged;

    [SerializeField]
    private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        ren = GetComponent<Renderer>();
        isChanged = false;
        orignalColor = ren.material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChanged)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                ren.material.color = orignalColor;
                isChanged = false;
                timer = 0;
                door.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {
            ren.material.color = changeColor;
            isChanged = true;
            door.SetActive(false);
        }
    }
}
