namespace BookShop.Application.WritingUtensils.Queries.GetUtensilByKeyWord
{
    using MediatR;

    public class GetUtensilByKeyWordQuery : IRequest<IEnumerable<WritingUtensilDto>>
    {
        public GetUtensilByKeyWordQuery(string keyWord)
        {
            this.KeyWord = keyWord;
        }

        public string KeyWord { get; set; }
    }
}
