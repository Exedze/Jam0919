using System;
using FMOD.Studio;
using UnityEngine;
using UnityEngine.Serialization;

public class Drowning : MonoBehaviour
{
    private int sources = 0;
    public bool headInWater;
    
    [SerializeField]
    private float drowningCurrent=0;
    [SerializeField]
    private float drowningMax = 20;
    [SerializeField] private float breatheInSpeed=2;
    [FormerlySerializedAs("_sound")] [SerializeField] private Sound _music;
    [SerializeField] private Sound _sfxTime;
    [SerializeField] private Sound _sfxVO;
    [SerializeField] private Sound _sfxMuffle;
    private bool isdrowning;
    

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
        _music.Supdate("Track",DrowningProgress*100);
        if (DrowningProgress >= 1f)
        {
            _sfxTime.Looping(false);
            _sfxMuffle.Stop();
        }
        if (DrowningProgress >= 0.5f)
        {
            if(!isdrowning)
            {
                _sfxTime.Play();
                _sfxVO.Looping(true); 
                isdrowning = true;
            }
            
        }
        else
        {
            if (isdrowning)
            {
                isdrowning = false;
                _sfxTime.Looping(false);
            }
        }
        if (DrowningProgress >= 0.8f)
        {
            if(!isdrowning)
            {
                _sfxMuffle.Play();
                _sfxMuffle.Looping(true); 
                isdrowning = true;
            }
            
        }
        else
        {
            if (isdrowning)
            {
                isdrowning = false;
                _sfxMuffle.Looping(false);
            }
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
        if (!headInWater)
        {
            _sfxVO.Looping(false);
        }

        drowningCurrent += Time.deltaTime;
        headInWater = true;
    }

    private void ExitWater()
    {
        if (headInWater)
        {
            _sfxVO.Looping(true);
            _sfxVO.Play();
            _sfxVO.Looping(true);
        }

        drowningCurrent -= Time.deltaTime*breatheInSpeed;
        if (drowningCurrent < 0) drowningCurrent = 0;
        headInWater = false;
    }
}