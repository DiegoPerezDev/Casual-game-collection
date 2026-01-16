using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelection : MonoBehaviour
{
    public void Button_CarrotCollector() => LoadSceneMode(1);
    public void Button_ThreeDDodger()    => LoadSceneMode(2);

    private void LoadSceneMode(int SceneBuildIndex) => SceneManager.LoadScene(SceneBuildIndex);

}
