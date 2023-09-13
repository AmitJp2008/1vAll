using UnityEngine;

[CreateAssetMenu(fileName = "New armor configurations", menuName = "Gameplay/Armor Data")]
public class ArmorConfigurationData : ScriptableObject 
{
    [SerializeField] private float activationTime;
    [SerializeField] private float loadTime;

    public float ActivationTime => activationTime;
    public float LoadTime => loadTime;
}
