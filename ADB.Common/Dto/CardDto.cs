namespace ADB.Common.Dto
{
    public class CardDto
    {

        public virtual string Number { get; set; }


        public virtual int ClientId { get; set; }


        public virtual int AccountId { get; set; }

        public virtual ClientDto ClientIdObject { get; set; }

        public virtual AccountDto AccountIdObject { get; set; }
    }
}