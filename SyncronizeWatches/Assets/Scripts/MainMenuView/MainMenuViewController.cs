using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuViewController : MonoBehaviour
{

    public GameObject TitleText;
    public List<Button> buttons;
    public string gameScene;

    // Use this for initialization
    void Start()
    {
        buttons[0].onClick.AddListener(StartGame);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // use this to initialize a game session, and then send over to the scene.
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
}
