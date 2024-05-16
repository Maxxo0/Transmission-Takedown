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
            DontDestroyOnLoad(gameObject);
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
    }

    public void Exit()
    {
        Application.Quit();
    }

}
