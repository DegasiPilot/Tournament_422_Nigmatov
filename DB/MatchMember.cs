//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tournament_422_Nigmatov.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class MatchMember
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MatchMember()
        {
            this.Match = new HashSet<Match>();
        }
    
        public int Id { get; set; }
        public Nullable<int> Match_Id { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> TournamentMember_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Match> Match { get; set; }
        public virtual Match Match1 { get; set; }
        public virtual TournamentMemeber TournamentMemeber { get; set; }
    }
}
