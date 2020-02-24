using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.ViewModels;
using Game.Models;

namespace UnitTests.ViewModels
{
    [TestFixture]
    public class BaseViewModelTests : BaseViewModel<ItemModel>
    {
        BaseViewModel<ItemModel> ViewModel;
    }
}
