using Unity.VisualScripting;
using UnityEngine;

public class movingWater : MonoBehaviour
{
    [SerializeField] private float startTime;

    [SerializeField] private float moveSpeed=1;
    [SerializeField] private Sound _sfxWaves;

    private float tottime = 0;

    private Vector3 startPos;

    [SerializeField] private Vector3 endPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        tottime += Time.deltaTime;
        if (tottime > startTime)
        {
            if((tottime - startTime) * moveSpeed>=1)
            {
                transform.position = endPos;
                _sfxWaves.Looping(false);
                //done moving
            }
            else
            {
                //moving
                transform.position = Vector3.Lerp(startPos, endPos, (tottime - startTime) * moveSpeed);
                _sfxWaves.Supdate("moveSpeed", (tottime - startTime) * moveSpeed);
            }
            
        }
    }
}
