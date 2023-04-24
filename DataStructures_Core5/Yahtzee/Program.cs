using System;
using System.Linq;
using System.Collections.Generic;

/*
    [RESOURCES]
    // Console.SetWindowSize() bug on Windonws 11
    https://stackoverflow.com/a/75537670
    https://stackoverflow.com/a/68345913
    https://www.reddit.com/r/csharp/comments/zvpvt9/comment/j1qfol2/?utm_source=share&utm_medium=web2x&context=3
    
    // Backspace and arrow keys annoyingly/randomly stop working
    https://jvides.wordpress.com/2010/11/18/backspace-and-arrow-keys-stop-working/
*/

namespace Yahtzee {
    class Program {
        const int NONE = -1;
        const int ONES = 0;
        const int TWOS = 1;
        const int THREES = 2;
        const int FOURS = 3;
        const int FIVES = 4;
        const int SIXES = 5;
        const int THREE_OF_A_KIND = 6;
        const int FOUR_OF_A_KIND = 7;
        const int FULL_HOUSE = 8;
        const int SMALL_STRAIGHT = 9;
        const int LARGE_STRAIGHT = 10;
        const int CHANCE = 11;
        const int YAHTZEE = 12;
        const int SUBTOTAL = 13;
        const int BONUS = 14;
        const int TOTAL = 15;

        static void Main() {
            List<int> uScorecard = new List<int>();
            List<int> cScorecard = new List<int>();
            int uTurns = 0;
            int cTurns = 0;
            bool uTurn = false;

            ResetScorecard(uScorecard, TOTAL);
            ResetScorecard(cScorecard, TOTAL);

            do {
                uTurn = !uTurn;
                UpdateScorecard(uScorecard);
                UpdateScorecard(cScorecard);
                DisplayScoreCards(uScorecard, cScorecard);
                if (uTurn) {
                    Console.WriteLine("\n\n[YOUR TURN]\n\nYou can roll 3 throws total. Rolling dice...");
                    Pause();
                    UserPlay(uScorecard, uTurns);
                } //else {
                        //Console.WriteLine("\n\n[COMPUTER'S TURN]\n\nWait for your own turn. Rolling dice...");
                        //ComputerPlay(cScorecard, cTurns);
                //v}
            } while ((uScorecard.Count <= YAHTZEE) && (cScorecard.Count <= YAHTZEE));
        }

        #region Scorecard Methods

        static void ResetScorecard(List<int> scorecard, int scorecardLength) {
            for (int i = 0; i <= scorecardLength; i++) scorecard.Add(NONE);
        }


        static void UpdateScorecard(List<int> scorecard) {
            scorecard[SUBTOTAL] = 0;
            scorecard[BONUS] = 0;

            for (int i = ONES; i <= SIXES; i++) if (scorecard[i] != -1) scorecard[SUBTOTAL] += scorecard[i];

            if (scorecard[SUBTOTAL] >= 63) scorecard[BONUS] = 35;

            scorecard[TOTAL] = scorecard[SUBTOTAL] + scorecard[BONUS];
            
            for (int i = THREE_OF_A_KIND; i <= YAHTZEE; i++) if (scorecard[i] != -1) scorecard[TOTAL] += scorecard[i];
        }

        static string FormatCell(int value) {
            return (value < 0) ? "" : value.ToString();
        }

        static void DisplayScoreCards(List<int> uScorecard, List<int> cScorecard) {
            string[] labels = {"Ones", "Twos", "Threes", "Fours", "Fives", "Sixes",
                "3 of a Kind", "4 of a Kind", "Full House", "Small Straight", "Large Straight",
                "Chance", "Yahtzee", "Sub Total", "Bonus", "Total Score"};
            string lineFormat = "| {3,2} {0,-15}|{1,8}|{2,8}|";
            string border = new string('-', 39);

            Console.Clear();
            Console.WriteLine(border);
            Console.WriteLine(string.Format(lineFormat, "", "  You   ", "Computer", ""));
            Console.WriteLine(border);
            for (int i = ONES; i <= SIXES; i++) Console.WriteLine(string.Format(lineFormat, labels[i], FormatCell(uScorecard[i]), FormatCell(cScorecard[i]), i));
            Console.WriteLine(border);
            Console.WriteLine(string.Format(lineFormat, labels[SUBTOTAL], FormatCell(uScorecard[SUBTOTAL]), FormatCell(cScorecard[SUBTOTAL]), ""));
            Console.WriteLine(border);
            Console.WriteLine(string.Format(lineFormat, labels[BONUS], FormatCell(uScorecard[BONUS]), FormatCell(cScorecard[BONUS]), ""));
            Console.WriteLine(border);
            for (int i = THREE_OF_A_KIND; i <= YAHTZEE; i++) Console.WriteLine(string.Format(lineFormat, labels[i], FormatCell(uScorecard[i]), FormatCell(cScorecard[i]), i));
            Console.WriteLine(border);
            Console.WriteLine(string.Format(lineFormat, labels[TOTAL], FormatCell(uScorecard[TOTAL]), FormatCell(cScorecard[TOTAL]), ""));
            Console.WriteLine(border);
        }
        #endregion

        #region Rolling Methods

        static void Roll(int numDice, List<int> dice) {
            dice.Clear();

            for (var i = 0; i < numDice; i++) dice.Add(new Random().Next(1, 6));
        }

        static void DisplayDice(List<int> dice) {
            string lineFormat = "|   {0}  |";
            string border = "*------*";
            string second = "|      |";

            foreach (int d in dice) Console.Write(border);
            Console.WriteLine();
            foreach (int d in dice) Console.Write(second);
            Console.WriteLine("");
            foreach (int d in dice) Console.Write(string.Format(lineFormat, d));
            Console.WriteLine();
            foreach (int d in dice) Console.Write(second);
            Console.WriteLine("");
            foreach (int d in dice) Console.Write(border);
            Console.WriteLine();
        }
        #endregion

        #region Computer Play Methods

        // figures out the highest possible score for the set of dice for the computer
        // takes the scorecard datastructure and the set of dice that the computer is keeping as it's parameters
        static int GetComputerScorecardItem(/* TODO */)
        {
            int indexOfMax = 0;
            int max = 0;

            /* you can uncomment this code once you've identified the parameters for this method
            for (int i = ONES; i <= YAHTZEE; i++)
            {
                if (scorecard[i] == -1)
                {
                    int score = Score(i, keeping);
                    if (score >= max)
                    {
                        max = score;
                        indexOfMax = i;
                    }
                }
            }
            */

            return indexOfMax;
        }

        // implements the computer's turn.  The computer only rolls once.
        // You can earn extra credit for making the computer play smarter
        // takes the computer's scorecard data structure and scorecard count as parameters.  Both are altered by the method.
        static void ComputerPlay(/* TODO */)
        {
            /* you can uncomment this code once you declare the parameters
            declare a data structure for the dice that the computer is keeping.  Call it keeping.
            int itemIndex = -1;

            Roll(5, keeping);
            Console.WriteLine("The dice the computer rolled: ");
            DisplayDice(keeping);
            Pause();
            Pause();

            itemIndex = GetComputerScorecardItem(cScorecard, keeping);
            cScorecard[itemIndex] = Score(itemIndex, keeping);
            cScorecardCount++;
            */
        }
        #endregion

        #region User Play Methods

        static void GetKeeping(List<int> rolling, List<int> keeping) {
            Console.Write("Enter a number for the dice you wish to remove [1]-[5] or enter [N] to continue: ");

            string promptKeep = Console.ReadLine();

            if (promptKeep == "n" || promptKeep == "N") return;
            else if (promptKeep == "1" || promptKeep == "2" || promptKeep == "3" || promptKeep == "4" || promptKeep == "5") {
                try {
                    rolling.RemoveAt(int.Parse(promptKeep) - 1);
                } catch {
                    Console.WriteLine("You must have at least 1 dice.");
                }
                for (var i = 0; i < rolling.Count; i++) keeping.Add(rolling[i]);
                Console.WriteLine("\n");
            } else Console.WriteLine("\n\nYou did not enter a number between 1-5. Try again.");

            DisplayDice(rolling);
            GetKeeping(rolling, keeping);
        }

        static void MoveRollToKeep(List<int> rolling, List<int> keeping) {
            for (var i = 0; i < rolling.Count; i++) keeping.Add(rolling[i]);
            rolling.Clear();
        }

        static int GetScorecardItem(List<int> scorecard) {
            int promptItemScore = int.Parse(Console.ReadLine());

            if (scorecard[promptItemScore] != -1) return scorecard.ElementAt(promptItemScore);

            return -1;
        }

        static void UserPlay(List<int> uScorecard, int uTurns) {
            List<int> rolling = new List<int>(){-1,-1,-1,-1,-1};
            List<int> keeping = new List<int>();
            int numRolls = 0;

            do {
                Roll(rolling.Count, rolling);

                numRolls++;

                Console.WriteLine("\n");

                if ((3 - numRolls) == 2 || (3 - numRolls) == 0) Console.WriteLine($"You have {3 - numRolls} throws left.");
                else if (3 - numRolls == 1) Console.WriteLine($"You have {3 - numRolls} throw left.");

                DisplayDice(rolling);

                //if (numRolls < 3) GetKeeping(rolling, keeping);
                //else MoveRollToKeep(rolling, keeping);

                //DisplayDice(rolling);
            } while (numRolls < 3 && keeping.Count < 5);

            //Console.Write("\n\nEnter a cell number between [1]-[13] for the scoreboard: ");

            //int promptItemScore = GetScorecardItem(uScorecard);
            //Console.WriteLine($"\n\nYour score is: {Score(0, rolling)}\n");
        }
        #endregion

        #region Scoring Methods

        static int Count() {
            int count = 0;

            return count;
        }

        static List<int> GetCounts(List<int> dice) {
            List<int> total = new List<int>();

            for (int i = 0; i < dice.Count; i++) total.Add(dice[i]);

            return total;
        }

        static int Sum(List<int> counts) {
            int sum = 0;

            for (int i = ONES; i <= SIXES; i++) {
                int value = i + 1;
                
                // This currently breaks for me
                //sum += (value * counts[i]);
            }

            return sum;
        }

        static bool HasCount(int howMany, List<int> counts) {
            foreach (int count in counts) if (howMany == count) return true;

            return false;
        }

        static int ScoreChance(List<int> counts) {
            return Sum(counts);
        }

        static int ScoreOnes(List<int> counts) {
            return counts[ONES] * 1;
        }

        static int ScoreTwos(List<int> counts) {
            return counts[TWOS] * 2;
        }

        static int ScoreThrees(List<int> counts) {
            return counts[THREES] * 3;
        }

        static int ScoreFours(List<int> counts) {
            return counts[FOURS] * 4;
        }

        static int ScoreFives(List<int> counts) {
            return counts[FIVES] * 4;
        }

        static int ScoreSixes(List<int> counts) {
            return counts[SIXES] * 5;
        }

        static int ScoreThreeOfAKind(List<int> counts) {
            int count = 0;

            for (var i = 0; i < counts.Count; i++) if (counts.Contains(counts[i])) {
                count++;
                if (count >= 3) return Sum(counts);
            }

            return -1;
        }

        static int ScoreFourOfAKind(List<int> counts) {
            int count = 0;

            for (var i = 0; i < counts.Count; i++) if (counts.Contains(counts[i])) {
                count++;
                if (count >= 4) return Sum(counts);
            }

            return -1;
        }

        static int ScoreYahtzee(List<int> counts) {
            int count = 0;

            for (var i = 0; i < counts.Count; i++) if (counts.Contains(counts[i])) {
                count++;
                if (count >= 5) return 50;
            }

            return -1;
        }

        static int ScoreFullHouse(List<int> counts) {
            if (HasCount(2, counts) && HasCount(3, counts)) return 25;

            else return 0;
        }

        static int ScoreSmallStraight(List<int> counts) {
            for (int i = THREES; i <= FOURS; i++) if (counts[i] == 0) return 0;

            if ((counts[ONES] >= 1 && counts[TWOS] >= 1) || (counts[TWOS] >= 1 && counts[FIVES] >= 1) || (counts[FIVES] >= 1 && counts[SIXES] >= 1)) return 30;
            else return 0;
        }

        static int ScoreLargeStraight(List<int> counts) {
            for (int i = TWOS; i <= FIVES; i++) if (counts[i] == 0) return 0;

            if (counts[ONES] == 1 || counts[SIXES] == 1) return 40;
            else return 0;
        }

        static int Score(int itemScore, List<int> dice) {
            List<int> counts = GetCounts(dice);

            itemScore = THREE_OF_A_KIND;

            switch (itemScore) {
                case ONES: return ScoreOnes(counts);
                case TWOS: return ScoreTwos(counts);
                case THREES: return ScoreThrees(counts);
                case FOURS: return ScoreFours(counts);
                case FIVES: return ScoreFives(counts);
                case SIXES: return ScoreSixes(counts);
                case THREE_OF_A_KIND: return ScoreThreeOfAKind(counts);
                case FOUR_OF_A_KIND: return ScoreFourOfAKind(counts);
                case FULL_HOUSE: return ScoreFullHouse(counts);
                case SMALL_STRAIGHT: return ScoreSmallStraight(counts);
                case LARGE_STRAIGHT: return ScoreLargeStraight(counts);
                case CHANCE: return ScoreChance(counts);
                case YAHTZEE: return ScoreYahtzee(counts);
                default: return 0;
            }
        }
        #endregion

        static void Pause() {
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }
}