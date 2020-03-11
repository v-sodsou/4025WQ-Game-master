using NUnit.Framework;

using Game.Engine;
using Game.Models;
using System.Threading.Tasks;
using Game.Helpers;
using System.Linq;
using Game.ViewModels;

namespace Scenario
{
    [TestFixture]
    public class HackathonScenarioTests
    {
        BattleEngineViewModel EngineViewModel = BattleEngineViewModel.Instance;

        AutoBattleEngine AutoBattleEngine;
        BattleEngine BattleEngine;

        [SetUp]
        public void Setup()
        {
            AutoBattleEngine = EngineViewModel.AutoBattleEngine;
            BattleEngine = EngineViewModel.Engine;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void HakathonScenario_Constructor_0_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      #
            *      
            * Description: 
            *      <Describe the scenario>
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      <List Files Changed>
            *      <List Classes Changed>
            *      <List Methods Changed>
            * 
            * Test Algrorithm:
            *      <Step by step how to validate this change>
            * 
            * Test Conditions:
            *      <List the different test conditions to make>
            * 
            * Validation:
            *      <List how to validate this change>
            *  
            */

            // Arrange

            // Act

            // Assert


            // Act
            var result = EngineViewModel;

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public async Task HackathonScenario_Scenario_1_Default_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      1
            *      
            * Description: 
            *      Make a Character called Mike, who dies in the first round
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      No Code changes requied 
            * 
            * Test Algrorithm:
            *      Create Character named Mike
            *      Set speed to -1 so he is really slow
            *      Set Max health to 1 so he is weak
            *      Set Current Health to 1 so he is weak
            *  
            *      Startup Battle
            *      Run Auto Battle
            * 
            * Test Conditions:
            *      Default condition is sufficient
            * 
            * Validation:
            *      Verify Battle Returned True
            *      Verify Mike is not in the Player List
            *      Verify Round Count is 1
            *  
            */

            //Arrange

            // Set Character Conditions

            EngineViewModel.Engine.MaxNumberPartyCharacters = 1;

            var CharacterPlayerMike = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = -1, // Will go last...
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            EngineViewModel.Engine.CharacterList.Add(CharacterPlayerMike);

            // Set Monster Conditions

            // Auto Battle will add the monsters


            //Act
            var result = await AutoBattleEngine.RunAutoBattle();

            //Reset

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(null, AutoBattleEngine.PlayerList.Find(m => m.Name.Equals("Mike")));
            Assert.AreEqual(1, AutoBattleEngine.BattleScore.RoundCount);
        }

        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Bob_Should_Miss()
        {
            /* 
             * Scenario Number:  
             *  2
             *  
             * Description: 
             *      Make a Character called Bob
             *      Bob Always Misses
             *      Other Characters Always Hit
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Change to Turn Engine
             *      Changed TurnAsAttack method
             *      Check for Name of Bob and return miss
             *                 
             * Test Algrorithm:
             *  Create Character named Bob
             *  Create Monster
             *  Call TurnAsAttack
             * 
             * Test Conditions:
             *  Test with Character of Named Bob
             *  Test with Character of any other name
             * 
             * Validation:
             *      Verify Enum is Miss
             *  
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 200,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 100,
                                ExperienceRemaining = 1,
                                Name = "Bob",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 19
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(19);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Miss, BattleEngine.BattleMessagesModel.HitStatus);
        }

        [Test]
        public async Task HackathonScenario_Scenario_32_Round1_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      32
            *      
            * Description: 
            *      Every 5th round, the sort order for turn order changes and list is sorted by Characters first, 
            *      then lowest health, then lowest speed
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update OrderPlayerListByTurnOrder method to check for every 5th round,
            *      and apply new sorting order rule if Round number is  5
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to 1 (slow)
            *      
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 1, so usual sort order should be applied
            * 
            * Validation:
            *      Verify fast Character is first in resulting list from sort
            *  
            */

            // Arrange
            BattleEngine.StartBattle(true);
            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            BattleEngine.MonsterList.Clear();
            BattleEngine.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Make the List
            BattleEngine.PlayerList = BattleEngine.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            BattleEngine.PlayerList = BattleEngine.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = BattleEngine.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("Z", result[0].Name);
            Assert.AreEqual(1, BattleEngine.BattleScore.RoundCount);
            Assert.AreEqual(true, true);
        }


        [Test]
        public async Task HackathonScenario_Scenario_32_Round5_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      32
            *      
            * Description: 
            *      Every 5th round, the sort order for turn order changes and list is sorted by Characters first, 
            *      then lowest health, then lowest speed
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update OrderEntityListByTurnOrder method to check for every 5th round,
            *      and apply new sorting order rule if Round number is a  5
            * 
            * Test Algorithm:
            *      Create Character
            *      Set speed to 1 (very slow)
            *      
            *      Complete 4 rounds
            *      Start New Round
            * 
            * Test Conditions:
            *      Round number is 5, so new hackathon sort order should be applied
            * 
            * Validation:
            *      Character is first in List
            *  
            */

        
            // Arrange
            BattleEngine.StartBattle(true);
            BattleEngine.NewRound();
            BattleEngine.NewRound();
            BattleEngine.NewRound();
            BattleEngine.NewRound();
            //BattleEngine.BattleScore.RoundCount = 5;

            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            BattleEngine.MonsterList.Clear();
            BattleEngine.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 2,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Make the List
            BattleEngine.PlayerList = BattleEngine.MakePlayerList();

            // Sort the list by Current Health, so it has to be resorted.
            BattleEngine.PlayerList = BattleEngine.PlayerList.OrderBy(m => m.CurrentHealth).ToList();

            // Act
            var result = BattleEngine.OrderPlayerListByTurnOrder();

            // Reset

            // Assert
            Assert.AreEqual("C", result[0].Name);
            Assert.AreEqual(5, BattleEngine.BattleScore.RoundCount);
            Assert.AreEqual(true, true);
        }


        [Test]
        public async Task HackathonScenario_Scenario_2_Character_Not_Bob_Should_Hit()
        {
            /* 
             * Scenario Number:  
             *      2
             *      
             * Description: 
             *      See Default Test
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      See Defualt Test
             *                 
             * Test Algrorithm:
             *      Create Character named Mike
             *      Create Monster
             *      Call TurnAsAttack so Mike can attack Monster
             * 
             * Test Conditions:
             *      Control Dice roll so natural hit
             *      Test with Character of not named Bob
             *  
             *  Validation
             *      Verify Enum is Hit
             *      
             */

            //Arrange

            // Set Character Conditions

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 200,
                                Level = 10,
                                CurrentHealth = 100,
                                ExperienceTotal = 100,
                                ExperienceRemaining = 1,
                                Name = "Mike",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions

            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 1,
                    Level = 1,
                    CurrentHealth = 1,
                    ExperienceTotal = 1,
                    ExperienceRemaining = 1,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(CharacterPlayer, MonsterPlayer);

            //Reset
            DiceHelper.DisableForcedRolls();

            //Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(HitStatusEnum.Hit, BattleEngine.BattleMessagesModel.HitStatus);
        }

        [Test]
        public async Task HackathonScenario_Scenario_9_Character_Revived_Once_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      9
             *      
             * Description: 
             *      Make one Character super weak and make it fight against a super strong monster and see if the character revived.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Instance of Monster and Character; 
             *      BattleEngine.TurnAsAttack;
             *      isAlive;
             *                 
             * Test Algrorithm:
             *      Create two Character
             *      Create Monster
             *      Call TurnAsAttack so one Character will die and Revived
             * 
             * Test Conditions:
             *      Check if the weak character is alive after receive a hit that cause his death.
             *  
             *  Validation
             *      Verify Alive = true;
             *      
             */

            //Arrange

            // Set Character Conditions

            var toggle = CharacterModel.EnableHackathon9;
            CharacterModel.EnableHackathon9 = true;

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Character",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions
            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 10,
                    Level = 10,
                    CurrentHealth = 10,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            var isAlive = CharacterPlayer.Alive;

            //Assert
            Assert.AreEqual(true, isAlive);
        }



        [Test]
        public async Task HackathonScenario_Scenario_9_Character_Revived_Toggle_Not_Triggered_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      9
             *      
             * Description: 
             *      Make one Character super weak and make it fight against a super strong monster and see if the character revived.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Instance of Monster and Character; 
             *      BattleEngine.TurnAsAttack;
             *      isAlive;
             *                 
             * Test Algrorithm:
             *      Create two Character
             *      Create Monster
             *      Call TurnAsAttack so one Character will die and Revived
             * 
             * Test Conditions:
             *      Check if the weak character is alive after receive a hit that cause his death.
             *  
             *  Validation
             *      Verify Alive = true;
             *      
             */

            //Arrange

            // Set Character Conditions

            var toggle = CharacterModel.EnableHackathon9;
            CharacterModel.EnableHackathon9 = false;

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Character",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions
            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 10,
                    Level = 10,
                    CurrentHealth = 10,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            var isAlive = CharacterPlayer.Alive;

            //Assert
            Assert.AreEqual(false, isAlive);
        }


        [Test]
        public async Task HackathonScenario_Scenario_9_Character_Died_Revived_Died_Should_Pass()
        {
            /* 
             * Scenario Number:  
             *      9
             *      
             * Description: 
             *      Make one Character super weak and make it fight against a super strong monster and see if the character revived and died again.
             * 
             * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
             *      Instance of Monster and Character; 
             *      BattleEngine.TurnAsAttack;
             *      isAlive;
             *                 
             * Test Algrorithm:
             *      Create one Character
             *      Create Monster
             *      Call TurnAsAttack so one Character will die and Revived
             * 
             * Test Conditions:
             *      Check if the weak character is alive after receive a hit(dead) that cause his death, revive and then died again
             *  
             *  Validation
             *      Verify Alive1 = true;
             *      Verify Alive2 = false;
             *      
             */

            //Arrange

            // Set Character Conditions

            var toggle = CharacterModel.EnableHackathon9;
            CharacterModel.EnableHackathon9 = true;

            BattleEngine.MaxNumberPartyCharacters = 1;

            var CharacterPlayer = new PlayerInfoModel(
                            new CharacterModel
                            {
                                Speed = 1,
                                Level = 1,
                                CurrentHealth = 1,
                                ExperienceTotal = 1,
                                ExperienceRemaining = 1,
                                Name = "Character",
                            });

            BattleEngine.CharacterList.Add(CharacterPlayer);

            // Set Monster Conditions
            // Add a monster to attack
            BattleEngine.MaxNumberPartyCharacters = 1;

            var MonsterPlayer = new PlayerInfoModel(
                new MonsterModel
                {
                    Speed = 10,
                    Level = 10,
                    CurrentHealth = 10,
                    ExperienceTotal = 10,
                    ExperienceRemaining = 10,
                    Name = "Monster",
                });

            BattleEngine.CharacterList.Add(MonsterPlayer);

            // Have dice roll 20
            DiceHelper.EnableForcedRolls();
            DiceHelper.SetForcedRollValue(20);

            //Act
            var result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);

            var isAlive1 = CharacterPlayer.Alive;

            //Make sure that the Monster Kill the Character
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            result = BattleEngine.TurnAsAttack(MonsterPlayer, CharacterPlayer);
            var isAlive2 = CharacterPlayer.Alive;

            //Assert
            Assert.AreEqual(true, isAlive1);
            Assert.AreEqual(false, isAlive2);
        }


        [Test]
        public async Task HackathonScenario_Scenario_33_Round13_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      33
            *      
            * Description: 
            *      For round 13, bad things happen to all the characters i.e their health gets bad just like that (decreases by 1)
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update NewRound method to check 13th round and call unlucky round method
            * 
            * Test Algorithm:
            *      Create Character
            *      Set CurrentHealth to 3 
            *      
            *     
            *      Start 13th Round
            * 
            * Test Conditions:
            *      Round number is 13, so all characters current health should be altered (decrease by 1)
            * 
            * Validation:
            *      Verify if Current health of all the characters health has been altered(decreased by 1) in the 13th round. 
            *  
            */


            // Arrange
            BattleEngine.StartBattle(true);


            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            BattleEngine.MonsterList.Clear();
            BattleEngine.MonsterList.Add(MonsterPlayer);

            var Character1 = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 3,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var Character2 = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 4,
                ExperienceTotal = 1,
                Name = "D",
                ListOrder = 10
            };

            var CharacterPlayer1 = new PlayerInfoModel(Character1);
            var CharacterPlayer2 = new PlayerInfoModel(Character2);
            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayer1);
            BattleEngine.CharacterList.Add(CharacterPlayer2);

            // Act
            for (int i = 1; i < 13; i++)
            {
                BattleEngine.NewRound();
            }

            //Check the character health in Round 13
            var characterC = BattleEngine.CharacterList.Find(m => m.Name == "C");
            var characterD = BattleEngine.CharacterList.Find(m => m.Name == "D");
            // Reset

            // Assert
            Assert.AreEqual(2, characterC.CurrentHealth);
            Assert.AreEqual(3, characterD.CurrentHealth);
            Assert.AreEqual(13, BattleEngine.BattleScore.RoundCount);
        }


        [Test]
        public async Task HackathonScenario_Scenario_33_Round2_Should_Pass()
        {
            /* 
            * Scenario Number:  
            *      33
            *      
            * Description: 
            *      For round 13, bad things happen to characters, their health gets lower (decreases by 1)
            * 
            * Changes Required (Classes, Methods etc.)  List Files, Methods, and Describe Changes: 
            *      RoundEngine class: update NewRound method to check 13th round and call unlucky round method
            * 
            * Test Algorithm:
            *      Create Character
            *      Set CurrentHealth to 3 
            *      
            *     
            *      Start Round 2 (Since it is not round 13 current health of the characters should not get altered)
            * 
            * Test Conditions:
            *      Round number is 2, so character current health should not be altered
            * 
            * Validation:
            *      Verify if Current health has altered. Since this Round 2 current health should not be altered.
            *  
            */


            // Arrange
            BattleEngine.StartBattle(true);


            var Monster = new MonsterModel
            {
                Speed = 20,
                Level = 20,
                CurrentHealth = 100,
                ExperienceTotal = 1000,
                Name = "Z",
                ListOrder = 1,
            };

            var MonsterPlayer = new PlayerInfoModel(Monster);
            BattleEngine.MonsterList.Clear();
            BattleEngine.MonsterList.Add(MonsterPlayer);

            var Character = new CharacterModel
            {
                Speed = 1,
                Level = 1,
                CurrentHealth = 3,
                ExperienceTotal = 1,
                Name = "C",
                ListOrder = 10
            };

            var CharacterPlayer = new PlayerInfoModel(Character);
            BattleEngine.CharacterList.Clear();
            BattleEngine.CharacterList.Add(CharacterPlayer);



            // Act
            BattleEngine.NewRound();
            var characterToCheck = BattleEngine.CharacterList.Find(m => m.Name == "C");
            // Reset

            // Assert
            Assert.AreEqual(3, characterToCheck.CurrentHealth);
            Assert.AreEqual(2, BattleEngine.BattleScore.RoundCount);
        }


    }
}