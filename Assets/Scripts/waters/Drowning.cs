using System;
using UnityEngine;

public class Drowning : MonoBehaviour
{
    private int sources = 0;
    public bool headInWater;
    
    [SerializeField]
    private float drowningCurrent=0;
    [SerializeField]
    private float drowningMax = 20;
    [SerializeField] private float breatheInSpeed=2;

    public float DrowningProgress
    {
        get
        {
            return (drowningCurrent / drowningMax);
        }
    }

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
        // fmod pass (DrowningProgress*100)
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
        if (!headInWater)
        {
            
        }

        drowningCurrent += Time.deltaTime;
        headInWater = true;
    }

    private void ExitWater()
    {
        if (headInWater)
        {
            
        }

        drowningCurrent -= Time.deltaTime*breatheInSpeed;
        if (drowningCurrent < 0) drowningCurrent = 0;
        headInWater = false;
    }
}