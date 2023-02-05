namespace TetrisRandomizers
{
	public class VanillaTetrisRandomizerBehaviour : ITetrisRandomizerBehaviour
	{
		private List<PieceType> _pieces = new(7) {PieceType.I, PieceType.J, PieceType.L, PieceType.O, PieceType.S, PieceType.T, PieceType.Z};

		public PieceType GetRandomPiece()
		{
			var random = new System.Random();

			var randomPiece = _pieces[random.Next(0, _pieces.Count)];

			return randomPiece;
		}
	}
}
