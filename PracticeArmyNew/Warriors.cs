using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeArmyNew
{
    public class Warriors
    {
        private string name;
        private float hp;
        private float attack;
        private float armor;
        private int speed;

        public Warriors(string SoldierName, float SoldierHp, float SoldierAttack, float SoldierArmor, int SoldierSpeed)
        {
            this.name = SoldierName;
            this.hp = SoldierHp;
            this.attack = SoldierAttack;
            this.armor = SoldierArmor;
            this.speed = SoldierSpeed;
        }
    /*      public string Name
        {
            get { return this.name; }
        }
    */
        public string Name => name;
        public float Hp => hp;
        public float Attack => attack;
        public float Armor => armor;
        public int Speed => speed;

        public bool IfUnitAlive()
        {
            if (this.hp <= 0)
            {
                return true;
            }        
            else return false;
        }

        public float DamageHit(float damage)
        {
            if (damage < this.armor)
            {
                this.armor -= damage;
                return this.armor;
            }
            else
            {
                this.hp = this.hp - damage + this.armor;
                this.armor = 0;
                return this.hp;
            }
        }
    }
}
