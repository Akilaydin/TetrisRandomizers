namespace TetrisRandomizers
{
	//note: uses Tetris Worlds and Onwards (2001) spawning algorithm. for more information about this algorithm, see https://simon.lc/the-history-of-tetris-randomizers
	public class TetrisWorldsRandomizerBehaviour : ITetrisRandomizerBehaviour
	{
		private List<PieceType> _piecesBag = new(7);
		
		PieceType ITetrisRandomizerBehaviour.GetRandomPiece()
		{
			if (_piecesBag.Count == 0)
			{
				FillBag();
				ShuffleBag();
			}

			var lastPiece = _piecesBag.Last();
			
			_piecesBag.Remove(lastPiece);
			
			return lastPiece;
		}
		
		private void FillBag()
		{
			_piecesBag.Add(PieceType.I);
			_piecesBag.Add(PieceType.J);
			_piecesBag.Add(PieceType.L);
			_piecesBag.Add(PieceType.O);
			_piecesBag.Add(PieceType.S);
			_piecesBag.Add(PieceType.T);
			_piecesBag.Add(PieceType.Z);
		}

		private void ShuffleBag()
		{
			_piecesBag = _piecesBag.OrderBy(_ => Guid.NewGuid()).ToList();
		}
	}
}
