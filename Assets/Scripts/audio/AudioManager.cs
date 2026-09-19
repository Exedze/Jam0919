using UnityEngine;
using FMODUnity;
using JetBrains.Annotations;

public class AudioManager : ScriptableObject
{
    private FMOD.Studio.EventInstance soundEvent;
   [SerializeField] private string paramName;
   [SerializeField] private string path;
   [SerializeField] private float paramValue;
   [SerializeField] private bool loop;
   
   
}
