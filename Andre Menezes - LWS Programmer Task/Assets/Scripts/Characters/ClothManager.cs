using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothManager : MonoBehaviour
{

    [SerializeField] private CharacterAllClothes clothes;

    public ClothType[] types;
    public string[] characterStates;
    private string[] characterDirections = { "Up", "Down", "Left", "Right" };

    private Animator animator;
    private AnimationClip animationClip;
    private AnimatorOverrideController animatorOverrideController;
    private AnimationClipOverrides defaultAnimationClips;

    //private AnimationClipOverrides defaulAnimationClips;s
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorOverrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        animator.runtimeAnimatorController = animatorOverrideController;

        defaultAnimationClips = new AnimationClipOverrides(animatorOverrideController.overridesCount);
        animatorOverrideController.GetOverrides(defaultAnimationClips);

        //UpdateBodyParts();
    }
    public void UpdateBodyParts()
    {
        // Override default animation clips with character body parts
        for (int partIndex = 0; partIndex < types.Length; partIndex++)
        {
            // Get current body part
            string partType = types[partIndex].ToString();
            // Get current body part ID
            string partID = clothes.AllClothesBase[partIndex].partReference.ClothAnimationID.ToString();

            for (int stateIndex = 0; stateIndex < characterStates.Length; stateIndex++)
            {
                string state = characterStates[stateIndex];
                for (int directionIndex = 0; directionIndex < characterDirections.Length; directionIndex++)
                {
                    string direction = characterDirections[directionIndex];

                    // Get players animation from player body
                    // ***NOTE: Unless Changed Here, Animation Naming Must Be: "[Type]_[Index]_[state]_[direction]" (Ex. Body_0_idle_down)
                    animationClip = Resources.Load<AnimationClip>("Clothes/" + partType + "s/" + partType + partID +"/"+ partType + "0" + partID + "_" + state + "_" + direction);
                   
                    // Override default animation
                    defaultAnimationClips[partType + "01" + "_" + state + "_" + direction] = animationClip;
                }
            }

        }
        animatorOverrideController.ApplyOverrides(defaultAnimationClips);
    } 
    public class AnimationClipOverrides : List<KeyValuePair<AnimationClip, AnimationClip>>
    {
        public AnimationClipOverrides(int capacity) : base(capacity) { }
        public AnimationClip this[string name]
        {
            get { return this.Find(x => x.Key.name.Equals(name)).Value; }
            set
            {
                int index = this.FindIndex(x => x.Key.name.Equals(name));
                if(index != -1)
                {
                    this[index] = new KeyValuePair<AnimationClip, AnimationClip>(this[index].Key, value);
                }
            }
        }
    }
}
