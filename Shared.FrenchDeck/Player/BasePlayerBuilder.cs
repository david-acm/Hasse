using System;
using Hasse.SharedKernel;

namespace Shared.CardGame.Player
{
	public abstract class BasePlayerBuilder<TPLayer> : LazyBuilder<TPLayer, BasePlayerBuilder<TPLayer>>
		where TPLayer : IPlayer
	{
		private string _name;

		public Type PlayerType => typeof(TPLayer); 

		public virtual BasePlayerBuilder<TPLayer> WithName(string name)
		{
			_name = name;
			return this;
		}
	}
}