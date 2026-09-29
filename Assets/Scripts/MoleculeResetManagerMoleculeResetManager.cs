using UnityEngine;

public class MoleculeResetManager : MonoBehaviour
{
    public MoleculeInteraction h2o;
    public MoleculeInteraction co2;
    public MoleculeInteraction ch4;
    public MoleculeInteraction nh3;

    public void ResetAllMolecules()
    {
        if (h2o != null)
            h2o.ResetMolecule();

        if (co2 != null)
            co2.ResetMolecule();

        if (ch4 != null)
            ch4.ResetMolecule();

        if (nh3 != null)
            nh3.ResetMolecule();
    }
}