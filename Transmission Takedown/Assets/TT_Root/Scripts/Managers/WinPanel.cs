using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Restart), 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
