using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delgate_and_event2
{
    class GameViewer
    {
      public  void GoodSpaceShipHPChangedEventHandler(object obj,PointEventArgs pointEvent)
        { Console.WriteLine($"the ship hit point is: {pointEvent.HitPoint}"); }
       public  void GoodSpaceShipLocationChangedEventHandler(object obj, LocationEventArgs locationEvent)
        { 
        Console.WriteLine($"the location of the ship: x={ locationEvent.X} y= {locationEvent.Y}");


        }
        public void GoodSpaceShipDestroyedEventHandler(object obj, LocationEventArgs locationEvent)
        {
            Console.WriteLine( "the ship destroyrd!");
        }
        public void BadShopExplodedEventHandler(object obj, BadShipsExplodedEventsArgs badShipsExplodedEvents)
        {
            Console.WriteLine($"{badShipsExplodedEvents.NumberOfExplodedBadShips} bad ship is exploded");
        }
        public void LevelUpReachedEventHandler(object obj,LevelEventArgs levelEventArgs)
        {
            Console.WriteLine($"you are finish a level!. now you in {levelEventArgs.CurrentLevel} level");
        
        }
    }
}
