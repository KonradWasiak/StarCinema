using StarCinema.Areas.Identity.Data;

namespace StarCinema.DomainModels
{
    public class Rate
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool IfLike { get; set; }
        public virtual StarCinemaUser User { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}