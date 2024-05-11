using System.ComponentModel.DataAnnotations;

namespace BeautySalon.Domain.Entities
{
    public abstract record BaseEntity<TKey> : IEntity where TKey : new()
    {
        [Key]
        public TKey Id { get; set; }

        // TODO
        // بهتر است تایپ تاریخ ها چه باشد؟
        // DateTime or DateTimeOffset
        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }

    public interface IEntity
    {

    }
}