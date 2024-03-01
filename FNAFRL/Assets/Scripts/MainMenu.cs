using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator anim1;
    public Animator anim2;
    public Animator anim3;
    public void Play()
    {
        SceneManager.LoadScene("Night 1");
    }

    public void Settings()
    {
        StartCoroutine(SettingsAnims());
    }

    public IEnumerator SettingsAnims()
    {
        anim1.SetBool("Play", true);
        yield return new WaitForSeconds(0.2f);
        anim2.SetBool("Play", true);
        yield return new WaitForSeconds(0.2f);
        anim3.SetBool("Play", true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
    }
}
