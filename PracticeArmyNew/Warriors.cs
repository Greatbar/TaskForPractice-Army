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

        public Warriors(string UnitName, float UnitHp, float UnitAttack, int UnitArmor, int UnitSpeed)
        {
            this.name = UnitName;
            this.attack = UnitAttack;
            this.armor = UnitArmor;
            this.speed = UnitSpeed;
            this.hp = UnitHp;
        }
        public string Name
        {
            get { return this.name; }
        }
        public float HP
        {
            get { return this.hp; }
        }

        public float Attack
        {
            get { return this.attack; }
        }

        public float Armor
        {
            get { return this.armor; }
        }

        public int Speed
        {
            get { return this.speed; }
        }
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
