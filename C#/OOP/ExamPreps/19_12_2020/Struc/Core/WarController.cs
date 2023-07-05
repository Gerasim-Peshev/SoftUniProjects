using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Characters;
using WarCroft.Entities.Characters.Contracts;
using WarCroft.Entities.Items;

namespace WarCroft.Core
{
	public class WarController 
    {
        private List<Character> characters;
        private List<Item> items;
        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

		public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = null;
            if (characterType == nameof(Warrior))
            {
                character = new Warrior(name);
            }
			else if (characterType == nameof(Priest))
            {
                character = new Priest(name);
            }
			else
            {
                throw new InvalidOperationException(
                    string.Format(ExceptionMessages.InvalidCharacterType, characterType));
            }

            this.characters.Add(character);
            return string.Format(SuccessMessages.JoinParty, name);
		}

		public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = null;
            if (itemName == nameof(FirePotion))
            {
                item = new FirePotion();
            }
            else if (itemName == nameof(HealthPotion))
            {
                item = new HealthPotion();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.InvalidItem, itemName);
            }

            this.items.Add(item);
            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

		public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            else if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }
            else
            {
                Item item = this.items.Last();
                character.Bag.AddItem(item);
                return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
            }
        }

		public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(x => x.Name == characterName);
            if (character == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }
            else
            {
                character.Bag.GetItem(itemName);
                return string.Format(SuccessMessages.UsedItem, character.Name, itemName);
            }
        }

		public string GetStats()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var character in characters.OrderByDescending(x=>x.IsAlive).ThenByDescending(x=>x.Health))
            {
                string alive = character.IsAlive == true ? "Alive" : "Dead";
                sb.AppendLine(
                    $"{character.Name} - HP: {character.Health}/{character.BaseHealth}, AP: {character.Armor}/{character.BaseArmor}, Status: {alive}");
            }

            return sb.ToString().TrimEnd();
        }

		public string Attack(string[] args)
		{
            string attackerName = args[0];
            string receiverName = args[1];

            Character attacker = this.characters.FirstOrDefault(x => x.Name == attackerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == receiverName);

            if (attacker == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }
            else if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            if (attacker.GetType().Name != nameof(Warrior))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }
            else
            {
                receiver.TakeDamage(attacker.AbilityPoints);
                StringBuilder sb = new StringBuilder();
                sb.AppendLine($"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! {receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and {receiver.Armor}/{receiver.BaseArmor} AP left!");
                if (receiver.IsAlive == false)
                {
                    sb.AppendLine($"{receiver.Name} is dead!");
                }

                return sb.ToString().TrimEnd();
            }
        }

		public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            Character healer = this.characters.FirstOrDefault(x => x.Name == healerName);
            Character receiver = this.characters.FirstOrDefault(x => x.Name == healingReceiverName);

            if (healer == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }
            else if (receiver == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            if (healerName.GetType().Name != nameof(Priest))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }
            else
            {
                receiver.Health += healer.AbilityPoints;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(
                    $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! {receiver.Name} has {receiver.Health} health now!");

                return sb.ToString().TrimEnd();
            }
        }
    }
}
