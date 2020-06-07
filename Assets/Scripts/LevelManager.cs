using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LevelManager : MonoBehaviour
{   
    //public int currScene; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadA(int scenenum){
        SceneManager.LoadScene(scenenum);
    }

    public void DelayedLoad(int scenenum){
        StartCoroutine(LoadDelay(scenenum, 2.0f));
    }

    public string currentSceneName(){
        return SceneManager.GetActiveScene().name; 
    }

    public int currentSceneNumber(){
        return SceneManager.GetActiveScene().buildIndex; 
    }

    IEnumerator LoadDelay(int scenenum, float time){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(scenenum);
    }
}
