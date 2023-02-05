namespace TetrisRandomizers
{
	public class NintendoTetrisRandomizerBehaviour : ITetrisRandomizerBehaviour
	{
		private List<PieceType> _pieces = new(7) {PieceType.I, PieceType.J, PieceType.L, PieceType.O, PieceType.S, PieceType.T, PieceType.Z};
		private PieceType _lastPiece = PieceType.None;
		
		PieceType ITetrisRandomizerBehaviour.GetRandomPiece()
		{
			var random = new System.Random();

			var randomPiece = _pieces[random.Next(0, _pieces.Count)];
			
			if (_lastPiece == randomPiece)
			{
				randomPiece = _pieces[random.Next(0, _pieces.Count)];
			}

			_lastPiece = randomPiece;
			
			return randomPiece;
		}
	}
}
