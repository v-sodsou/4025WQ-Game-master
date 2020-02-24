﻿using NUnit.Framework;

using Game.Models;

namespace UnitTests.Models
{
    [TestFixture]
    class BattleMessageModelTests
    {
        [Test]
        public void BattleMessageModel_Constructor_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleMessagesModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void BattleMessageModel_Get_Default_Should_Pass()
        {
            // Arrange

            // Act
            var result = new BattleMessagesModel();

            // Reset

            // Assert
            Assert.IsNotNull(result);

            Assert.AreEqual(PlayerTypeEnum.Unknown, result.PlayerType);

            Assert.AreEqual(HitStatusEnum.Unknown, result.HitStatus);

            Assert.AreEqual(string.Empty, result.AttackerName);
            Assert.AreEqual(string.Empty, result.TargetName);
            Assert.AreEqual(string.Empty, result.AttackStatus);
            Assert.AreEqual(string.Empty, result.TurnMessage);
            Assert.AreEqual(string.Empty, result.TurnMessageSpecial);
            Assert.AreEqual(string.Empty, result.LevelUpMessage);

            Assert.AreEqual(0, result.DamageAmount);
            Assert.AreEqual(0, result.CurrentHealth);

            Assert.AreEqual(@"<html><body bgcolor=""#E8D0B6""><p>", result.htmlHead);
            Assert.AreEqual(@"</p></body></html>", result.htmlTail);
        }
    }
}
