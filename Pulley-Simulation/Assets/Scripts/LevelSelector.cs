using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static LevelSelector main;

    private void Awake()
    {
        main = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
/*        if (Input.GetMouseButtonDown(1)) {
            GoToHome();
        }*/
    }
    public void GoToHome()
    {
        GoToScene("SimulationSelector");
    }

    public void GoToScene(string level) {
        SceneManager.LoadScene(level);
    }
}
