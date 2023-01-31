using Core.Base;

namespace Data.Dto
{
    public class StateDto /*: BaseEntity*/
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int StateCode { get; set; }

    }
}
