using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] Health playerHP;
    public float restartDelay = 10f;
    float restartTimer=0f;
    bool DefeatStinger = false;
    AudioSource audio = null;
    void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerHP.getCurrentHP() <= 0)
        {
            if (!DefeatStinger)
            {
                audio.Play();
                DefeatStinger = true;
            }
            restartTimer += Time.deltaTime;
            if (restartTimer >= restartDelay)
            {
                SceneManager.LoadScene(0);
                //     Application.LoadLevel(Application.loadedLevel);
            }

        }
    }

}
