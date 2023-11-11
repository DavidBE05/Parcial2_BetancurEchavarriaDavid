namespace Parcial3_BetancurEchavarriaDavid.DAL.Entities
{
    public class Tickets
    { 
        public Guid Id { get; set; }

        public DateTime UseDate { get; set; }
 
        public bool IsUsed { get; set; }

        public string EntranceGate { get; set; }

        public Tickets(Guid id, DateTime useDate, bool isUsed, string entranceGate)
        {
            Id = id;
            UseDate = useDate;
            IsUsed = isUsed;
            EntranceGate = entranceGate;
        }

    }
}
