using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    public void Load(int index)
    {
        SaveLoadManager.control = 1;
       
        SceneManager.LoadScene(index);
    }
    public void LoadLastGame(int index)
    {
        SaveLoadManager.control = 0;
        SceneManager.LoadScene(index);
    }
}
