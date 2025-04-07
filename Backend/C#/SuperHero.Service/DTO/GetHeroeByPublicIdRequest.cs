using MediatR;

namespace SuperHero.Service.DTO
{
    public record GetHeroeByPublicIdRequest : IRequest<GetHeroeByPublicIdResponse>
    {
        public string PublicId { get; set; }

        public GetHeroeByPublicIdRequest(string publicId)
        {
            PublicId = publicId;
        }
    }
}
