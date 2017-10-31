using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void NextScene(string namescene)
    {
        SceneManager.LoadScene(namescene);
    }
}
