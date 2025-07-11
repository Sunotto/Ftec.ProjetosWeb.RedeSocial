namespace Web.Models
{
    public class CurtidaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdUsuario { get; set; }
        public DateTime DataCurtida { get; set; }
        public TipoReacao Reacao { get; set; }
        public Guid IdPostPai { get; set; }
    }
    public enum TipoReacao
    {
        Like = 0,
        Love = 1,
        Happy = 2,
        HaHa = 3,
        Think = 4,
        Sade = 5,
        Lovely = 6
    }
}
