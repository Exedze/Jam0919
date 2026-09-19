using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Drowning playerDrowning;

    [SerializeField] private Sound music;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        music.Play();
        music.Looping(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerDrowning.DrowningProgress > 1)
        {
            music.Looping(false);
            SceneManager.LoadScene(0);
        }
    }
}
