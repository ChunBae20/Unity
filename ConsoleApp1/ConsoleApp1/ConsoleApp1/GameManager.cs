using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class GameManager
    {

        public static bool isGameover = false;

        public static PlayerInfo player = new PlayerInfo();
        public static InventoryInfo inventoryInfo = new InventoryInfo();
        public static EquipManager equipManager = new EquipManager();
        public static Store store = new Store();
        public static Purchase purchase = new Purchase();
      //  public static MainScene mainscene = new MainScene();


    }


    /*
    public class Player
    {
        public static Player playerOne = new Player();
        
       
    }

    public class Inventory
    {
        public static Inventory inventoryOne = new Inventory();
    }
    */
   /*
    public class EquipManager
    {
        public static EquipManager equipManagerOne = new EquipManager();
    }
  
    
    */
    
    /*public class MainScene
    {
        public static MainScene mainscene = new MainScene();
    }
    */
}
