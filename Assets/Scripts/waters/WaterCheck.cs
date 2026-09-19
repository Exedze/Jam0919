using System;
using UnityEngine;

public class WaterCheck : MonoBehaviour
{
    private int sources = 0;
    public bool inWater;

    [SerializeField] private Rigidbody2D body;

    // Update is called once per frame
    void Update()
    {
        if (sources > 0)
        {
            EnterWater();
        }
        else
        {
            ExitWater();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Water")
        {
            sources += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Water")
        {
            sources -= 1;
        }
    }

    private void EnterWater()
    {
        if (!inWater)
        {
            body.gravityScale = 0;
        }
        
        inWater = true;
    }

    private void ExitWater()
    {
        if (inWater)
        {
            body.gravityScale = 1;
        }

        inWater = false;
    }
}
