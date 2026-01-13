using UnityEngine;
using TMPro;

public class PlantCountUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _plantedText;
    [SerializeField] private TMP_Text _remainingText;

    public void UpdateSeeds (int seedsLeft, int seedsPlanted)
    {

        //Con esto necesitas actualizar el texto el UI
        //pero es importante asignarlo al script pplayer 
        //porque enonces si se actualiza 
        //al igual que la compudadora.
        
        _plantedText.text = seedsPlanted.ToString();
        _remainingText.text = seedsLeft.ToString();
    }
}