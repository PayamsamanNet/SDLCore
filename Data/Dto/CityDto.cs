using Core.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Dto
{
    public class CityDto/* : BaseEntity*/
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }

        public int CityCode { get; set; }

        public Guid StateId { get; set; }
        //[ForeignKey(nameof(StateId))]
        public virtual StateDto? State { get; set; }


    }
}
