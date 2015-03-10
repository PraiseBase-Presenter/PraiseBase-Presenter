namespace PraiseBase.Presenter.Model.Song
{
    /// <summary>
    /// Song tempo in bpm (beats per minute, maybe 30-250) or some words like
    /// Very Fast, Fast, Moderate, Slow, Very Slow -->
    /// </summary>
    public class SongTempo
    {
        public string Type { get; set; }

        public string Value { get; set; }

        protected bool Equals(SongTempo other)
        {
            return string.Equals(Type, other.Type) && string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SongTempo) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Type != null ? Type.GetHashCode() : 0)*397) ^ (Value != null ? Value.GetHashCode() : 0);
            }
        }
    }
}