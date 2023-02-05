namespace TetrisRandomizers
{
	//note: uses Tetris: The Grand Master 3 - Terror-Instinct (2005) randomizer algorithm. for more information about this algorithm, see https://tetris.fandom.com/wiki/TGM_randomizer, http://tetrisconcept.net/threads/randomizer-theory.512/page-9#post-55478 and https://simon.lc/the-history-of-tetris-randomizers
	public class TerrorInstinctRandomizerBehaviour : ITetrisRandomizerBehaviour
	{
		private List<PieceType> _piecesPool = new(35);
		private List<PieceType> _piecesHistory = new(4);
		private List<PieceType> _piecesOrder = new(4);

		private PieceType[] _piecesToSpawnFirst = { PieceType.I, PieceType.J, PieceType.L, PieceType.T };

		private bool _firstSpawn = true;
		
		PieceType ITetrisRandomizerBehaviour.GetRandomPiece()
		{
			var random = new System.Random();
			
			if (_firstSpawn)
			{
				_firstSpawn = false;

				var firstPiece = _piecesToSpawnFirst[random.Next(0, _piecesToSpawnFirst.Length)];

				FillPool();
				
				FillHistoryFirstTime(firstPiece);

				return firstPiece;
			}

			var randomPieceIndex = 0;
			var randomPiece = PieceType.None;

			for (var roll = 0; roll < 6; ++roll)
			{
				randomPieceIndex = random.Next(0, _piecesPool.Count);
				randomPiece = _piecesPool[randomPieceIndex];

				if (_piecesHistory.Contains(randomPiece) == false || roll == 5)
				{
					break;
				}

				if (_piecesOrder.Count > 0)
				{
					_piecesPool[randomPieceIndex] = _piecesOrder[0];
				}
			}

			if (_piecesOrder.Contains(randomPiece))
			{
				_piecesOrder.Remove(randomPiece);
			}

			_piecesOrder.Add(randomPiece);
			_piecesPool[randomPieceIndex] = _piecesOrder[0];

			_piecesHistory.RemoveAt(0);
			_piecesHistory.Add(randomPiece);

			return randomPiece;
		}
		
		private void FillPool()
		{
			AddTimes(_piecesPool, PieceType.I, 5);
			AddTimes(_piecesPool, PieceType.J, 5);
			AddTimes(_piecesPool, PieceType.L, 5);
			AddTimes(_piecesPool, PieceType.O, 5);
			AddTimes(_piecesPool, PieceType.S, 5);
			AddTimes(_piecesPool, PieceType.T, 5);
			AddTimes(_piecesPool, PieceType.Z, 5);

			void AddTimes<T>(List<T> sourceList, T item, int times)
			{
				for (int i = 0; i < times; i++)
				{
					sourceList.Add(item);
				}
			}
		}
		
		private void FillHistoryFirstTime(PieceType firstPiece)
		{
			_piecesHistory.Add(PieceType.S);
			_piecesHistory.Add(PieceType.Z);
			_piecesHistory.Add(PieceType.S);
			_piecesHistory.Add(firstPiece);
		}
	}
}
