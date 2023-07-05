using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }
                else
                {
                    this.name = value;
                }
            }
        }

        public double BaseHealth  { get; set; }

        public double Health
        {
            get => this.health;
            set
            {
                this.health = value;
                if (this.health < 0)
                {
                    this.health = 0;
                }

                if (this.health > this.BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
            }
        }
        public double BaseArmor  { get; set; }

        public double Armor
        {
            get => this.armor;
            set
            {
                this.armor = value;
                if (this.armor < 0)
                {
                    this.armor = 0;
                }

                if (this.armor > this.BaseArmor)
                {
                    this.armor = this.BaseArmor;
                }
            }
        }

        public double AbilityPoints  { get; set; }
        public Bag Bag { get; set; }

        public bool IsAlive { get; set; } = true;

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public void TakeDamage(double hitPoints)
        {
            if (this.IsAlive)
            {
                double beforeArmor = this.Armor;
                this.Armor -= hitPoints;
                if (this.Armor == 0)
                {
                    this.Health += (beforeArmor - hitPoints);
                }

                if (this.Health <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }
    }
}