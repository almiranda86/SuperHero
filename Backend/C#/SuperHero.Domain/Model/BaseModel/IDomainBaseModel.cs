using System.Text.Json.Serialization;

namespace SuperHero.Domain.Model.BaseModel
{
    public interface IDomainBaseModel : IGuidId, IPrivateId
    {
        public string Name { get; set; }
    }
}
