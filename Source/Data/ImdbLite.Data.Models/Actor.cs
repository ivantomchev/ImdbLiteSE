namespace ImdbLite.Data.Models
{
    using System.Collections.Generic;

    using ImdbLite.Data.Models.Base;
    using ImdbLite.Data.Models;
    
    public class Actor : CastMember
    {
        private ICollection<Character> characters;

        public Actor()
            : base()
        {
            this.characters = new HashSet<Character>();         
        }

        public virtual ICollection<Character> Characters
        {
            get
            {
                return this.characters;
            }

            set
            {
                this.characters = value;
            }
        }
    }
}
