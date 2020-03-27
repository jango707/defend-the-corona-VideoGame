using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScripts : MonoBehaviour
{
    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
