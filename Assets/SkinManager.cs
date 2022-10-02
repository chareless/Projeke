using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkinManager : MonoBehaviour
{
    public void wizardButton()
    {
        PlayerStats.ourClass = "Wizard";
        SceneManager.LoadScene("SampleScene");
    }
    public void RogueButton()
    {
        PlayerStats.ourClass = "Rogue";
        SceneManager.LoadScene("SampleScene");
    }
    public void ArcherButton()
    {
        PlayerStats.ourClass = "Archer";
        SceneManager.LoadScene("SampleScene");
    }
}
