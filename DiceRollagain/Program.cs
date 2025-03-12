using System;
using System.Diagnostics.CodeAnalysis;

namespace Program
{
    class Program
    {   

        //TO-DO Add Advantage System from Baldur's Gate 3 (MAYBE PLAY IT FIRST!)

        //Declarations
        Random random = new Random(); //Needed for accessing random class
        public bool x = true;
        public int dicecount;
        public int sides;
        public int bonusdices;
        public int statbonus;
        public int sum;
        public int pass;
        public int bonusdicesides;

        static void Main(string[] args)
        {
            Program program = new Program();
            program.sum = 0;

            //Main Dice Rolling Algorithm
            while (program.x)
            {
                program.sum = 0;
                program.Inputs();

                //Rolling for each dice
                for (int i = 1; i <= program.dicecount; i++)
                {
                    Console.WriteLine($"How many sides are the {i}. dice? ");
                    program.sides = Convert.ToInt32(Console.ReadLine());
                    program.Rolla(program.sides);
                }

                //Rolling for Bonus Dices
                for (int i = 1; i <= program.bonusdices; i++)
                {
                    Console.WriteLine($"How many sides are the {i}. bonus dice? ");
                    program.bonusdicesides = Convert.ToInt32(Console.ReadLine());
                    program.Rolla(program.bonusdicesides);
                }

                program.sum += program.statbonus;

                //SKILL CHECK!
                if (program.sum >= program.pass)
                {
                    Console.WriteLine($"{program.sum}/{program.pass}! PASSED the Skill Check! ");
                }
                else
                {
                    Console.WriteLine($"{program.sum}/{program.pass}! FAILED the Skill Check! ");
                }

                //Continue 10..9..8..7..6..5...
                Console.WriteLine("Wanna Rollagain? [Y/N] ");
                String Continue = Console.ReadLine();
                Continue = Continue.ToUpper(); //Better safe then sorry

                switch (Continue)
                {
                    case "Y":
                        break;
                    case "N":
                        program.x = false;
                        break;
                    default:
                        Console.WriteLine("Y or N ? FAILED to write correctly! "); //DM can punish this way I think?
                        program.x = false;
                        break;
                }
            }

            Console.ReadKey(); //Looks Better
        }

        public void Inputs()
            //Asking for every dice that you gotta roll + your non-rolled bonuses
        {
            Console.WriteLine("How many main Dice to roll? ");
            dicecount = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many static Bonuses? ");
            statbonus = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("How many Bonus dice? ");
            bonusdices = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("How much to pass? ");
            pass = Convert.ToInt32(Console.ReadLine());
        }

        public void Rolla(int sides)
            //Rolla Dice!
        {
            int dice = random.Next(1,(sides+1));
            Console.WriteLine($"You rolla {dice}!");
            sum += dice;
        }
    }
}
