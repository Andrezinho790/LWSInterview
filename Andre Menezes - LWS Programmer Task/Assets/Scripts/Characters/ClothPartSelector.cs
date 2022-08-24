using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClothPartSelector : MonoBehaviour
{
    //Full Character Body
    [SerializeField] private CharacterAllClothes allClothes;

    //Cloth part Selections
    [SerializeField]
    private List<ClothPartSelection> clothSelections;

    public ClothManager manager;
    // Start is called before the first frame update
    void Start()
    {
        //Get All Current Cloth Parts
        for(int i = 0; i< clothSelections.Count; i++)
        {
            GetCurrentClothParts(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            NextClothPart(1);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            PreviousClothPart(1);
        }
    }

    [System.Serializable]
    public class ClothPartSelection
    {
        public ClothType type;
        public ClothObject[] clothOptions;
        public Text clothPartNameTextComponent;
        [HideInInspector] public int clothPartCurrentIndex;
    }

    private void GetCurrentClothParts(int partIndex)
    {
        clothSelections[partIndex].clothPartCurrentIndex = allClothes.AllClothesBase[partIndex].partReference.ClothAnimationID;
    }

    public void NextClothPart(int partIndex)
    {
        if (ValidateIndex(partIndex))
        {
            if(clothSelections[partIndex].clothPartCurrentIndex < clothSelections[partIndex].clothOptions.Length - 1)
            {
                clothSelections[partIndex].clothPartCurrentIndex++;
            }
            else
            {
                clothSelections[partIndex].clothPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }
    public void PreviousClothPart(int partIndex)
    {
        if (ValidateIndex(partIndex))
        {
            if (clothSelections[partIndex].clothPartCurrentIndex > 0)
            {
                clothSelections[partIndex].clothPartCurrentIndex--;
            }
            else
            {
                clothSelections[partIndex].clothPartCurrentIndex = clothSelections[partIndex].clothOptions.Length -1;
            }

            UpdateCurrentPart(partIndex);
        }

    }

    public bool ValidateIndex(int index)
    {
        if(index < 0 || index > clothSelections.Count)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void UpdateCurrentPart(int partIndex)
    {
        allClothes.AllClothesBase[partIndex].partReference = clothSelections[partIndex].clothOptions[clothSelections[partIndex].clothPartCurrentIndex];
        manager.UpdateBodyParts();
    }
}
