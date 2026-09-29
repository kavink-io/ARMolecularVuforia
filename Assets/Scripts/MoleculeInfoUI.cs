using UnityEngine;
using TMPro;

public class MoleculeInfoUI : MonoBehaviour
{
    public TextMeshProUGUI infoText;
    public GameObject infoPanel;

    private string currentMolecule = "";

    void Start()
    {
        HideInfo();
    }

    // =========================
    // SHOW H2O
    // =========================

    public void ShowH2O()
    {
        currentMolecule = "H2O";

        infoPanel.SetActive(true);

        infoText.text =
            "<b>H2O</b>\n" +
            "Water\n\n" +
            "Formula: H2O\n" +
            "Atoms: 3\n" +
            "Molecular Mass: 18.015 g/mol\n" +
            "Bond Angle: 104.5°";
    }

    // =========================
    // SHOW CO2
    // =========================

    public void ShowCO2()
    {
        currentMolecule = "CO2";

        infoPanel.SetActive(true);

        infoText.text =
            "<b>CO2</b>\n" +
            "Carbon Dioxide\n\n" +
            "Formula: CO2\n" +
            "Atoms: 3\n" +
            "Molecular Mass: 44.01 g/mol\n" +
            "Bond Angle: 180°";
    }

    // =========================
    // SHOW CH4
    // =========================

    public void ShowCH4()
    {
        currentMolecule = "CH4";

        infoPanel.SetActive(true);

        infoText.text =
            "<b>CH4</b>\n" +
            "Methane\n\n" +
            "Formula: CH4\n" +
            "Atoms: 5\n" +
            "Molecular Mass: 16.04 g/mol\n" +
            "Bond Angle: 109.5°";
    }

    // =========================
    // SHOW NH3
    // =========================

    public void ShowNH3()
    {
        currentMolecule = "NH3";

        infoPanel.SetActive(true);

        infoText.text =
            "<b>NH3</b>\n" +
            "Ammonia\n\n" +
            "Formula: NH3\n" +
            "Atoms: 4\n" +
            "Molecular Mass: 17.03 g/mol\n" +
            "Bond Angle: 107°";
    }

    // =========================
    // TARGET LOST
    // =========================

    public void HideH2O()
    {
        if (currentMolecule == "H2O")
        {
            HideInfo();
        }
    }

    public void HideCO2()
    {
        if (currentMolecule == "CO2")
        {
            HideInfo();
        }
    }

    public void HideCH4()
    {
        if (currentMolecule == "CH4")
        {
            HideInfo();
        }
    }

    public void HideNH3()
    {
        if (currentMolecule == "NH3")
        {
            HideInfo();
        }
    }

    public void HideInfo()
    {
        currentMolecule = "";
        infoPanel.SetActive(false);
    }
}