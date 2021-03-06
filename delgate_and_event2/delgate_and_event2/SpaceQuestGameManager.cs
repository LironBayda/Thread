using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delgate_and_event2
{
    class SpaceQuestGameManager
    {
        readonly int _goodSpaceShipHitPointasTheBegining;
       int _goodSpaceShipHitPoint;
        int _shipXLocation;
        int _shipYLocation;
        int _numberOfBadShips;
        int _level;
        int _last_bad_ship_destroyed;

       public event EventHandler<PointEventArgs> GoodSpaceShipHPChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipLocationChanged;
        public event EventHandler<LocationEventArgs> GoodSpaceShipDestroyed;
        public event EventHandler<BadShipsExplodedEventsArgs> BadShopExploded;
        public event EventHandler<LevelEventArgs> LevelUpReached;

        public SpaceQuestGameManager(int goodSpaceShipHitPoint, int shipXLocation, int shipYLocation, int numberOfBadShips)
        {
            _goodSpaceShipHitPointasTheBegining = goodSpaceShipHitPoint;
            _goodSpaceShipHitPoint = goodSpaceShipHitPoint;
            _shipXLocation = shipXLocation;
            _shipYLocation = shipYLocation;
            _numberOfBadShips = numberOfBadShips;
            _level = 1;

           
        }

        public int GetLevel()
        {
            return _level;
        }

        public int GetHitPoint()
        {
            return _goodSpaceShipHitPoint;
        
        }

        public int GetNumberOfBadShips()
        {
            return _numberOfBadShips;

        }
        public void MoveSpaceShip(int newX, int newY)
        {
            _shipXLocation = newX;
            _shipYLocation = newY;
            onGoodSpaceShipLocationChanged();
        
        }

        public void GoodSpaceShipGotDamaged(int damage)
        {
            _goodSpaceShipHitPoint -= damage;
            onGoodSpaceShipHPChanged();
            if (_goodSpaceShipHitPoint < 0)
            {
                _shipXLocation = 0;
                _shipYLocation = 0;
                onGoodSpaceShipDestroyed();
                onGoodSpaceShipLocationChanged();
            }
        
        }
        public void GoodSpaceShipGotExtreHP(int extra)
        {
            _goodSpaceShipHitPoint += extra;
            onGoodSpaceShipHPChanged();
            


        }

        public void EnemyShipDestroyed(int numberOfBadShipsDestroyed)
        {

            _numberOfBadShips -= numberOfBadShipsDestroyed;
            _last_bad_ship_destroyed = numberOfBadShipsDestroyed;
            onBadShopExploded();
            if (_numberOfBadShips == 0)
            {
                _goodSpaceShipHitPoint = _goodSpaceShipHitPointasTheBegining;
                _numberOfBadShips = 33;
                onLevelUpReached();

            }
        }

         void onGoodSpaceShipHPChanged()
        {
           
            
                if (GoodSpaceShipHPChanged != null)
                {
                    PointEventArgs e = new PointEventArgs
                    {
                        HitPoint = _goodSpaceShipHitPoint

                    };
                    GoodSpaceShipHPChanged.Invoke(this, e);

                
                }
        }
         void onGoodSpaceShipLocationChanged()
        {
            if (GoodSpaceShipLocationChanged != null)
            {
                LocationEventArgs e = new LocationEventArgs
                {

                    X = _shipXLocation,
                    Y = _shipYLocation

                };

                GoodSpaceShipLocationChanged.Invoke(this, e);
            }
        
        }
         void onGoodSpaceShipDestroyed()
        {

            if (GoodSpaceShipDestroyed != null)
            {

                LocationEventArgs e = new LocationEventArgs
                {

                    X = _shipXLocation,
                    Y = _shipYLocation

                };
                GoodSpaceShipDestroyed.Invoke(this, e);
            }
        }
         void onBadShopExploded()
        {
            if (GoodSpaceShipDestroyed != null)

            {
                BadShipsExplodedEventsArgs e = new BadShipsExplodedEventsArgs
                {
                    NumberOfExplodedBadShips = _last_bad_ship_destroyed

                };
                BadShopExploded.Invoke(this, e);
            }
        }
        void onLevelUpReached()
        {
            if (LevelUpReached != null)
            {

                LevelEventArgs e = new LevelEventArgs
                {

                    CurrentLevel = ++_level

                };

                LevelUpReached.Invoke(this, e);
            }
        
        }
    }
}
