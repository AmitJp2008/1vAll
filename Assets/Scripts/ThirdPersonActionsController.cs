using UnityEngine;
using StarterAssets;

public class ThirdPersonActionsController : MonoBehaviour 
{
    private StarterAssetsInputs starterAssetsInputs;
    public StarterAssetsInputs StarterAssetsInputs => starterAssetsInputs;
    public void SetStarterAssetsInputs(StarterAssetsInputs starterAssetsInputs) 
    {
        this.starterAssetsInputs = starterAssetsInputs;
    }
}
