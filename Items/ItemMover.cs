using Internal.Codebase.SwipeSystem;
using UnityEngine;

namespace Internal.Codebase.GameplayLogic.Items
{
    public class ItemMover
    {
        private readonly Rigidbody itemRb;

        private float pushForce = 35;
        
        public ItemMover(Rigidbody itemRb) => 
            this.itemRb = itemRb;

        public void MoveSideways(Sides side)
        {
            switch (side)
            {
                case Sides.Right:
                    itemRb.AddForce(pushForce,0,0);
                    break;
                case Sides.Left:
                    itemRb.AddForce(-pushForce,0,0);
                    break;
            }
        }
    }
}
