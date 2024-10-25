using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerStem : MonoBehaviour
{
    private Transform flower;

    [SerializeField]
    private LineRenderer line;
    // Start is called before the first frame update
    private void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    public void targetFlower(Vector3 startPosition, Transform target)
    {
        line.positionCount = 2;
        line.SetPosition(0, startPosition);
        flower = target;
    }
    // Update is called once per frame
    void Update()
    {
        line.SetPosition(1, flower.position);
    }
}
