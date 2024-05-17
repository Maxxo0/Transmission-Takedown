using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {

                Debug.Log("GameManager is null!");
            }
            return instance;
        }
    }

    public GameObject optionsMenu;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        optionsMenu.SetActive(true);
    }

    public void ExitOptions(InputAction.CallbackContext context)
    {
        optionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenOptions(InputAction.CallbackContext context)
    {
        optionsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

}
