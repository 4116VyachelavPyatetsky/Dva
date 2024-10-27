using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_transition_scr : MonoBehaviour
{
    Animator anim;
    public int scenenum;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("New_scene");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(scenenum, LoadSceneMode.Single);
        anim.SetTrigger("New_scene");
    }
}
