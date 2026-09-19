using System;
using FMOD.Studio;
using UnityEngine;
using FMODUnity;
using JetBrains.Annotations;
using UnityEditor;

[CreateAssetMenu(menuName ="Sound")]
public class Sound : ScriptableObject
{
    [SerializeField] private string paramName;
   [SerializeField] private string paramName2;
   [SerializeField] private EventReference soundName;
   [SerializeField] private float paramValue;
   [SerializeField] private float loop;
   private EventInstance soundEvent;

   /*private void Awake()
   {
       if (soundName.IsNull)
       {
           Debug.Log("Sound ref is Null");
       }
       soundEvent = FMOD.Studio.
           CreateInstance(soundName);
   }*/
   
   public void Stop()
   {
       soundEvent.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
       soundEvent.release();
   }
   public void Play()
   {
       soundEvent = RuntimeManager.CreateInstance(soundName);
       soundEvent.start();
   }
   
   public void Supdate(string param, float value)
   {
       paramName = param;
       paramValue = value;
       soundEvent.setParameterByName(paramName, paramValue);
   }public void Supdate(string param, float value, string param2, float value2)
   {
       paramName = param;
       paramName = param2;
       paramValue = value;
       soundEvent.setParameterByName(paramName, paramValue);
   }

  public void Looping(bool value)
   {
       if (value == true)
       {
           loop = 1;
       }
       else
       {
           loop = 0;
       }

       soundEvent.setParameterByName("looping", loop);
       if (loop == 0)
       {
           soundEvent.release();
       }
   }
   
   
}
