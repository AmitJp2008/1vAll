using UnityEngine;

namespace StarterAssets
{
    public class ThirdPersonInputDistributer : MonoBehaviour 
	{
		[SerializeField] StarterAssetsInputs starterAssetsInputs;
		[SerializeField] ThirdPersonActionsController[] thirdPersonActionsControllers;
		
		private void Awake()
		{
			InjectInputSystem(thirdPersonActionsControllers, starterAssetsInputs);
		}

		public void InjectInputSystem(ThirdPersonActionsController[] thirdPersonActionsControllers, StarterAssetsInputs starterAssetsInputs)
		{
			foreach (var controller in thirdPersonActionsControllers)
			{
				controller.SetStarterAssetsInputs(starterAssetsInputs);
			}
		}
	}
}
