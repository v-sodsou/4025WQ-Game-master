﻿using Game.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Engine
{
    /// <summary>
    /// BaseEngine Class
    /// </summary>
    public class BaseEngine
    {
        #region Properties

        // Holds the official ScoreModel
        public ScoreModel BattleScore = new ScoreModel();

        // Holds the Battle Messages as they happen
        public BattleMessagesModel BattleMessagesModel = new BattleMessagesModel();

        // The Pool of items collected during the round as turns happen
        public List<ItemModel> ItemPool = new List<ItemModel>();

        // List of Monsters
        public List<PlayerInfoModel> MonsterList = new List<PlayerInfoModel>();

        // List of Characters
        public List<PlayerInfoModel> CharacterList = new List<PlayerInfoModel>();

        // Current Player who is the attacker
        public PlayerInfoModel CurrentAttacker;

        // Current Player who is the Defender
        public PlayerInfoModel CurrentDefender;

        // Hold the list of players (MonsterModel, and character by guid), and order by speed
        public List<PlayerInfoModel> PlayerList = new List<PlayerInfoModel>();

        // Player currently engaged
        public PlayerInfoModel PlayerCurrent;

        // Current Round State
        public RoundEnum RoundStateEnum = RoundEnum.Unknown;

        // Max Number of Characters
        public int MaxNumberPartyCharacters = 6;

        // Max Number of Monsters
        public int MaxNumberPartyMonsters = 6;

        // Hold the MapModel
        public MapModel MapModel = new MapModel();

        // The Action 
        public ActionEnum CurrentAction;

        // The Action that just happened
        public ActionEnum PreviousAction = ActionEnum.Unknown;

        // When the current action is an ability, what ability was selected
        public AbilityEnum CurrentActionAbility;

        // Hold the Battle Settings
        public BattleSettingsModel BattleSettingsModel = new BattleSettingsModel();


        #endregion Properties
    }
}
