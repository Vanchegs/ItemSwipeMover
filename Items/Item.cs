using UnityEngine;

namespace Internal.Codebase.GameplayLogic.Items
{
    public class Item : MonoBehaviour
    {
        public ItemMover ItemMover { get; private set; }
        
        [field: SerializeField] public Rigidbody ItemRb { get; private set; }

        private void Start() => 
            ItemMover = new ItemMover(ItemRb);
    }
}