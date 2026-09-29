using UnityEngine;

public class MoleculeTargetVisibility : MonoBehaviour
{
    public GameObject moleculeModel;

    public void ShowMolecule()
    {
        if (moleculeModel != null)
            moleculeModel.SetActive(true);
    }

    public void HideMolecule()
    {
        if (moleculeModel != null)
            moleculeModel.SetActive(false);
    }
}