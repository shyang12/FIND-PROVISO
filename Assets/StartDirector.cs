using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartDirector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickNewGame()
    {
        SceneManager.LoadScene("Deep_Tunnel_set");
    }

    public void OnClickStory()
    {
        SceneManager.LoadScene("Story");
    }

    public void OnClickHow()
    {
        SceneManager.LoadScene("How");
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }
}
