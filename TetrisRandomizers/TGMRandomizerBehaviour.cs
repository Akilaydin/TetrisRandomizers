namespace TetrisRandomizers
{
	//note: uses TGM (1998) randomizer algorithm. For more information, see https://simon.lc/the-history-of-tetris-randomizers
	public class TGMRandomizerBehaviour : ITetrisRandomizerBehaviour
	{
		private List<PieceType> _pieces = new(7) {PieceType.I, PieceType.J, PieceType.L, PieceType.O, PieceType.S, PieceType.T, PieceType.Z};
		private List<PieceType> _piecesHistory = new(4);

		private PieceType[] _piecesToSpawnFirst = { PieceType.I, PieceType.J, PieceType.L, PieceType.T };

		private bool _firstSpawn = true;

		PieceType ITetrisRandomizerBehaviour.GetRandomPiece()
		{
			var random = new System.Random();
			
			if (_firstSpawn)
			{
				_firstSpawn = false;

				var firstPiece = _piecesToSpawnFirst[random.Next(0, _piecesToSpawnFirst.Length)];

				FillHistoryFirstTime(firstPiece);

				return firstPiece;
			}

			var randomPiece = PieceType.None;

			for (var roll = 0; roll < 4; ++roll)
			{
				randomPiece = _pieces[random.Next(0, _pieces.Count)];

				if (_piecesHistory.Contains(randomPiece) == false)
				{
					break;
				}
			}

			_piecesHistory.RemoveAt(0);
			_piecesHistory.Add(randomPiece);

			return randomPiece;
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
