
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace delgate_and_event2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameViewer gameViewer = new GameViewer();
            SpaceQuestGameManager spaceQuestGameManager = new SpaceQuestGameManager(33,15,15,7);
            Random gen = new Random();

            spaceQuestGameManager.BadShopExploded += gameViewer.BadShopExplodedEventHandler;
            spaceQuestGameManager.GoodSpaceShipLocationChanged += gameViewer.GoodSpaceShipLocationChangedEventHandler;
            spaceQuestGameManager.GoodSpaceShipDestroyed += gameViewer.GoodSpaceShipDestroyedEventHandler;
            spaceQuestGameManager.GoodSpaceShipHPChanged += gameViewer.GoodSpaceShipHPChangedEventHandler;
            spaceQuestGameManager.LevelUpReached += gameViewer.LevelUpReachedEventHandler;

            while (spaceQuestGameManager.GetHitPoint() != 0 && spaceQuestGameManager.GetLevel() < 3)
            {

                spaceQuestGameManager.GoodSpaceShipGotDamaged(gen.Next(1,5));
                Thread.Sleep(1000);
                spaceQuestGameManager.GoodSpaceShipGotExtreHP(gen.Next(1,22));
                Thread.Sleep(1000);
              spaceQuestGameManager.MoveSpaceShip(gen.Next(1,20),gen.Next(1,20));
                Thread.Sleep(1000);
                spaceQuestGameManager.EnemyShipDestroyed(gen.Next(1, spaceQuestGameManager.GetNumberOfBadShips()));
                Thread.Sleep(1000);

            }

            Console.ReadLine();
        }
    }
}
